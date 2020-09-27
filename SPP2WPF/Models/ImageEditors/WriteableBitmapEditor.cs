using SPP2.Models.ImageEditors;
using SPP2.Models.ImageEditors.Generic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Media = System.Windows.Media;
using Draw = System.Drawing;
using System.Windows;
using SPP2.Extensions;

namespace SPP2WPF.Models.ImageEditors
{
    public class WriteableBitmapEditor : IImageEditor<WriteableBitmap>
    {
        public event EventHandler CurrentImageChanged;

        private WriteableBitmap currentImage;

        public WriteableBitmap CurrentImage
        {
            get => currentImage;
            set
            {
                currentImage = value;
                CurrentImageChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public WriteableBitmapEditor()
            :this(default)
        {

        }
        public WriteableBitmapEditor(WriteableBitmap image)
        {
            CurrentImage = image;
        }

        public IImageEditor<WriteableBitmap> Contrast(double ratio)
        {
            if (CurrentImage == null)
                return this;

            CurrentImage = CurrentImage.AdjustContrast(ratio);

            return this;
        }
        public IImageEditor<WriteableBitmap> DrawLine(Draw.Point point1, Draw.Point point2, Draw.Color color, float thickness)
        {
            if (CurrentImage == null)
                return this;

            var winColor = Media.Color.FromArgb(color.A, color.R, color.G, color.B);
            CurrentImage.DrawLineAa(point1.X, point1.Y, point2.X, point2.Y, winColor, (int)thickness);

            return this;
        }
        public IImageEditor<WriteableBitmap> DrawRectangle(Rectangle rect, Draw.Color color)
        {
            if (CurrentImage == null)
                return this;

            var winColor = Media.Color.FromArgb(color.A, color.R, color.G, color.B);
            CurrentImage.DrawRectangle(rect.Left, rect.Top, rect.Right, rect.Bottom, winColor);

            return this;
        }
        public IImageEditor<WriteableBitmap> Lighten(double ratio)
        {
            if (CurrentImage == null)
                return this;

            CurrentImage = CurrentImage.AdjustBrightness((int)ratio);

            return this;
        }
        public IImageEditor<WriteableBitmap> Resize(Draw.Size newSize)
        {
            if (CurrentImage == null)
                return this;

            var newBitmap = CurrentImage.Resize(newSize.Width, newSize.Height, WriteableBitmapExtensions.Interpolation.Bilinear);
            newBitmap.FillRectangle(0, 0, newSize.Width, newSize.Height, Media.Colors.White);

            var rect = new Rect(
                0, 0, newSize.Width, newSize.Height);
            var destRect = new Rect(
                (CurrentImage.PixelWidth - newSize.Width) / 2,
                (CurrentImage.PixelHeight - newSize.Height) / 2, 
                newSize.Width, newSize.Height);

            if (newSize.Width > CurrentImage.PixelWidth)
            {
                rect.X = (newSize.Width - CurrentImage.PixelWidth) / 2;
                rect.Width = CurrentImage.PixelWidth;

                destRect.X = 0;
                destRect.Width = CurrentImage.PixelWidth;
            }

            if (newSize.Height > CurrentImage.PixelHeight)
            {
                rect.Y = (newSize.Height - CurrentImage.PixelHeight) / 2;
                rect.Height = CurrentImage.PixelHeight;

                destRect.Y = 0;
                destRect.Height = CurrentImage.PixelHeight;
            }


            newBitmap.Blit(rect, CurrentImage, destRect);

            CurrentImage = newBitmap;

            return this;
        }
        public IImageEditor<WriteableBitmap> Rotate(double angle)
        {
            if (CurrentImage == null)
                return this;

            while (angle < 0)
                angle += 360;
            angle %= 360;

            CurrentImage = CurrentImage.Rotate((int)angle);

            return this;
        }
        public IImageEditor<WriteableBitmap> Saturate(double ratio)
        {
            if (CurrentImage == null)
                return this;

            ratio /= 100;
            var arr = new byte[CurrentImage.PixelWidth * CurrentImage.PixelHeight * 4];
            CurrentImage.CopyPixels(arr, CurrentImage.PixelWidth * 4, 0);

            for (int i = 0; i < arr.Length; i += 4)
            {
                var drawingColor = Draw.Color.FromArgb(arr[i + 3], arr[i + 2], arr[i + 1], arr[i]);
                var colorHSB = drawingColor.ToAhsb();

                colorHSB.S += (float)ratio;

                if (colorHSB.S > 1)
                    colorHSB.S = 1;
                if (colorHSB.S < 0)
                    colorHSB.S = 0;

                drawingColor = colorHSB.ToArgb();
                arr[i + 3] = drawingColor.A;
                arr[i + 2] = drawingColor.R;
                arr[i + 1] = drawingColor.G;
                arr[i + 0] = drawingColor.B;
            }

            CurrentImage.WritePixels(
                new Int32Rect(0, 0, CurrentImage.PixelWidth, CurrentImage.PixelHeight),
                arr, CurrentImage.PixelWidth * 4, 0);
            

            return this;
        }
        public IImageEditor<WriteableBitmap> Scale(Draw.Size newSize)
        {
            if (CurrentImage == null)
                return this;

            CurrentImage = CurrentImage.Resize(newSize.Width, newSize.Height, 
                WriteableBitmapExtensions.Interpolation.Bilinear);

            return this;
        }
    }
}
