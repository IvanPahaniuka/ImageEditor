using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SPP2WinForms.View.SizeForm
{
    public partial class SizeForm : Form
    {
        private int widthValue;
        private int heightValue;

        public int WidthValue
        {
            get => widthValue;
            set
            {
                widthValue = value;
                if (textBox1 != null && textBox1.Text != widthValue.ToString())
                    textBox1.Text = widthValue.ToString();
            }
        }
        public int HeightValue
        {
            get => heightValue;
            set
            {
                heightValue = value;
                if (textBox2 != null && textBox2.Text != heightValue.ToString())
                    textBox2.Text = heightValue.ToString();
            }
        }

        public SizeForm()
        {
            InitializeComponent();

            textBox1.Text = WidthValue.ToString();
            textBox2.Text = HeightValue.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out var res))
                WidthValue = res;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out var res))
                HeightValue = res;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
