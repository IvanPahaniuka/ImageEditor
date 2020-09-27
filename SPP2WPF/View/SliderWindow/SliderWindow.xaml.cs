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

namespace SPP2WPF.View.SliderWindow
{
    /// <summary>
    /// Логика взаимодействия для SliderWindow.xaml
    /// </summary>
    public partial class SliderWindow : Window
    {
        public static readonly RoutedCommand Apply;

        public double Value
        {
            get => slider.Value;
            set => slider.Value = value;
        }
        public double MaxValue
        {
            get => slider.Maximum;
            set => slider.Maximum = value;
        }
        public double MinValue
        {
            get => slider.Minimum;
            set => slider.Minimum = value;
        }

        static SliderWindow()
        {
            Apply = new RoutedCommand(nameof(Apply), typeof(SliderWindow));
        }
        public SliderWindow()
        {
            InitializeComponent();
        }

        private void CommandBinding_Apply(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
