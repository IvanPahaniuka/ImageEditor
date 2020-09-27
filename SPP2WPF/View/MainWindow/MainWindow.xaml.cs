using Microsoft.Win32;
using SPP2.Models.ImageEditors;
using SPP2.Models.ImageEditors.Generic;
using SPP2WPF.Models.ImageEditors;
using SPP2WPF.View.SliderWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SysDraw = System.Drawing;

namespace SPP2WPF.View.MainWindow
{
    public partial class MainWindow : Window
    {
        public static readonly RoutedCommand Rotate90;
        public static readonly RoutedCommand RotateR90;
        public static readonly RoutedCommand Rotate180;
        public static readonly RoutedCommand Contrast;
        public static readonly RoutedCommand Lighten;
        public static readonly RoutedCommand Saturate;
        public static readonly RoutedCommand Resize;
        public static readonly RoutedCommand Scale;

        private IImageEditor<WriteableBitmap> imageEditor;
        private System.Windows.Point? lastPosition;

        public WriteableBitmap Image
        {
            get => (WriteableBitmap)img.Source;
            set => img.Source = value;
        }

        static MainWindow()
        {
            Rotate90 = new RoutedCommand(nameof(Rotate90), typeof(MainWindow));
            RotateR90 = new RoutedCommand(nameof(RotateR90), typeof(MainWindow));
            Rotate180 = new RoutedCommand(nameof(Rotate180), typeof(MainWindow));
            Contrast = new RoutedCommand(nameof(Contrast), typeof(MainWindow));
            Lighten = new RoutedCommand(nameof(Lighten), typeof(MainWindow));
            Saturate = new RoutedCommand(nameof(Saturate), typeof(MainWindow));
            Resize = new RoutedCommand(nameof(Resize), typeof(MainWindow));
            Scale = new RoutedCommand(nameof(Scale), typeof(MainWindow));
        }
        public MainWindow()
        {
            InitializeComponent();

            imageEditor = new WriteableBitmapEditor();
            imageEditor.CurrentImageChanged += ImageEditor_CurrentImageChanged;
            imageEditor.CurrentImage = new WriteableBitmap(1, 1, 96, 96, PixelFormats.Bgra32, null);
        }

        private void ImageEditor_CurrentImageChanged(object sender, EventArgs e)
        {
            if (Image != imageEditor.CurrentImage)
            {
                Image = imageEditor.CurrentImage;
            }
        }
        private void CommandBinding_Open(object sender, ExecutedRoutedEventArgs e)
        {
            var OF = new OpenFileDialog();
            if (OF.ShowDialog() == true)
            {
                imageEditor.CurrentImage = new WriteableBitmap(new BitmapImage(new Uri(OF.FileName)));
            }
        }
        private void CommandBinding_Save(object sender, ExecutedRoutedEventArgs e)
        {
            var SF = new SaveFileDialog();
            if (SF.ShowDialog() == true)
            {
                using (var FS = new FileStream(SF.FileName, FileMode.Create))
                {
                    var ext = System.IO.Path.GetExtension(SF.FileName).ToLower();
                    BitmapEncoder encoder;
                    switch (ext)
                    {
                        case "jpg":
                        case "jpeg":
                            encoder = new JpegBitmapEncoder();
                            break;
                        case "gif":
                            encoder = new GifBitmapEncoder();
                            break;
                        case "bmp":
                            encoder = new BmpBitmapEncoder();
                            break;
                        default:
                            encoder = new PngBitmapEncoder();
                            break;
                    }
                    
                    encoder.Frames.Add(BitmapFrame.Create(imageEditor.CurrentImage));
                    encoder.Save(FS);
                }
            }
        }
        private void CommandBinding_Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = imageEditor.CurrentImage != null;
        }
        private void CommandBinding_Rotate90(object sender, ExecutedRoutedEventArgs e)
        {
            imageEditor.Rotate(90);
        }
        private void CommandBinding_RotateR90(object sender, ExecutedRoutedEventArgs e)
        {
            imageEditor.Rotate(-90);
        }
        private void CommandBinding_Rotate180(object sender, ExecutedRoutedEventArgs e)
        {
            imageEditor.Rotate(180);
        }
        private void CommandBinding_Contrast(object sender, ExecutedRoutedEventArgs e)
        {
            var SW = new SliderWindow.SliderWindow();
            SW.MaxValue = 100;
            SW.MinValue = -100;
            if (SW.ShowDialog() == true)
            {
                imageEditor.Contrast(SW.Value);
            }
        }
        private void CommandBinding_Lighten(object sender, ExecutedRoutedEventArgs e)
        {
            var SW = new SliderWindow.SliderWindow();
            SW.MaxValue = 100;
            SW.MinValue = -100;
            if (SW.ShowDialog() == true)
            {
                imageEditor.Lighten(SW.Value);
            }
        }
        private void CommandBinding_Saturate(object sender, ExecutedRoutedEventArgs e)
        {
            var SW = new SliderWindow.SliderWindow();
            SW.MaxValue = 100;
            SW.MinValue = -100;
            if (SW.ShowDialog() == true)
            {
                imageEditor.Saturate(SW.Value);
            }
        }
        private void CommandBinding_Resize(object sender, ExecutedRoutedEventArgs e)
        {
            var SW = new SizeWindow.SizeWindow();
            SW.WidthValue = Image.PixelWidth;
            SW.HeightValue = Image.PixelHeight;
            if (SW.ShowDialog() == true)
            {
                imageEditor.Resize(new SysDraw.Size(SW.WidthValue, SW.HeightValue));
            }
        }
        private void CommandBinding_Scale(object sender, ExecutedRoutedEventArgs e)
        {
            var SW = new SizeWindow.SizeWindow();
            SW.WidthValue = Image.PixelWidth;
            SW.HeightValue = Image.PixelHeight;
            if (SW.ShowDialog() == true)
            {
                imageEditor.Scale(new SysDraw.Size(SW.WidthValue, SW.HeightValue));
            }
        }
        private void img_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var tmpPos = e.GetPosition(img);
                tmpPos.X *= Image.Width / img.ActualWidth;
                tmpPos.Y *= Image.Height / img.ActualHeight;

                if (lastPosition != null)
                {
                    
                    var drawPoint1 = new SysDraw.Point((int)lastPosition.Value.X, (int)lastPosition.Value.Y);
                    var drawPoint2 = new SysDraw.Point((int)tmpPos.X, (int)tmpPos.Y);
                    var drawColor = SysDraw.Color.Black;
                    imageEditor.DrawLine(drawPoint1, drawPoint2, drawColor, 5);
                }

                lastPosition = tmpPos;
            }
            else
                lastPosition = null;
        }
        private void img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lastPosition = e.GetPosition(img);
            lastPosition = new System.Windows.Point(
                lastPosition.Value.X * Image.Width / img.ActualWidth,
                lastPosition.Value.Y * Image.Height / img.ActualHeight);
        }
        private void img_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lastPosition = null;
        }

        ~MainWindow()
        {
            imageEditor.CurrentImageChanged -= ImageEditor_CurrentImageChanged;
        }
    }
}
