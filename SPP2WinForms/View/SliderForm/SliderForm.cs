using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SPP2WinForms.View.SliderForm
{
    public partial class SliderForm : Form
    {
        private int value;
        private int maxValue;
        private int minValue;

        public int Value
        {
            get => value;
            set
            {
                this.value = value;
                if (this.trackBar1 != null && this.trackBar1.Value != value)
                    this.trackBar1.Value = value;
            }
        }
        public int MaxValue
        {
            get => maxValue;
            set
            {
                maxValue = value;
                if (this.trackBar1 != null && this.trackBar1.Maximum != value)
                    this.trackBar1.Maximum = value;
            }
        }
        public int MinValue
        {
            get => minValue;
            set
            {
                minValue = value;
                if (this.trackBar1 != null && this.trackBar1.Minimum != value)
                    this.trackBar1.Minimum = value;
            }
        }

        public SliderForm()
        {
            InitializeComponent();

            trackBar1.Value = Value;
            trackBar1.Minimum = MinValue;
            trackBar1.Maximum = MaxValue;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.label2.Text = string.Format("{0:D0}", this.trackBar1.Value);
            Value = trackBar1.Value;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
