using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SPP2WPF.View.SizeWindow
{
    /// <summary>
    /// Логика взаимодействия для SizeWindow.xaml
    /// </summary>
    public partial class SizeWindow : Window
    {
        public static readonly RoutedCommand Apply;

        public int WidthValue
        {
            get => Convert.ToInt32(width.Text);
            set => width.Text = value.ToString();
        }
        public int HeightValue
        {
            get => Convert.ToInt32(height.Text);
            set => height.Text = value.ToString();
        }

        static SizeWindow()
        {
            Apply = new RoutedCommand(nameof(Apply), typeof(SizeWindow));
        }
        public SizeWindow()
        {
            InitializeComponent();
        }

        private void CommandBinding_Apply(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
