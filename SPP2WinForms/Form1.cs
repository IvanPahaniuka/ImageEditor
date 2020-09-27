using SPP2.Models.ImageEditors.Generic;
using SPP2WinForms.View.SizeForm;
using SPP2WinForms.View.SliderForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPP2WinForms
{
    public partial class Form1 : Form
    {
        private ImageEditor imageEditor;
        private Point? lastPosition;

        public Form1()
        {
            imageEditor = new ImageEditor(new Bitmap(1, 1));

            InitializeComponent();

            imageEditor.CurrentImageChanged += ImageEditor_CurrentImageChanged;
            UpdateImage();
        }

        private void UpdateImage()
        {
            this.pictureBox1.Image = imageEditor.CurrentImage;
        }
        private void ImageEditor_CurrentImageChanged(object sender, EventArgs e)
        {
            UpdateImage();
        }
        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var OF = new OpenFileDialog();
            if (OF.ShowDialog() == DialogResult.OK)
            {
                imageEditor.CurrentImage = new Bitmap(OF.FileName);
            }
        }
        private void ToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            imageEditor.Rotate(90);
        }
        private void ToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            imageEditor.Rotate(-90);
        }
        private void ToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            imageEditor.Rotate(180);
        }
        private void ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var SF = new SliderForm();
            SF.MaxValue = 100;
            SF.MinValue = -100;
            if (SF.ShowDialog() == DialogResult.OK)
            {
                imageEditor.Contrast((double)SF.Value);
            }
        }
        private void ToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            var SF = new SliderForm();
            SF.MaxValue = 100;
            SF.MinValue = -100;
            if (SF.ShowDialog() == DialogResult.OK)
            {
                imageEditor.Lighten((double)SF.Value);
            }
        }
        private void ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            var SF = new SliderForm();
            SF.MaxValue = 100;
            SF.MinValue = -100;
            if (SF.ShowDialog() == DialogResult.OK)
            {
                imageEditor.Saturate((double)SF.Value);
            }
        }
        private void ToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            var SF = new SizeForm();
            SF.WidthValue = imageEditor.CurrentImage.Width;
            SF.HeightValue = imageEditor.CurrentImage.Height;
            if (SF.ShowDialog() == DialogResult.OK)
            {
                imageEditor.Scale(new Size(SF.WidthValue, SF.HeightValue));
            }
        }
        private void ToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            var SF = new SizeForm();
            SF.WidthValue = imageEditor.CurrentImage.Width;
            SF.HeightValue = imageEditor.CurrentImage.Height;
            if (SF.ShowDialog() == DialogResult.OK)
            {
                imageEditor.Resize(new Size(SF.WidthValue, SF.HeightValue));
            }
        }
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) > 0)
            {
                var tmpPos = e.Location;
                var k1 = imageEditor.CurrentImage.Width * 1.0 / pictureBox1.Width;
                var k2 = imageEditor.CurrentImage.Height * 1.0 / pictureBox1.Height;
                var k = Math.Max(k1, k2);
                tmpPos.X = (int)(tmpPos.X * k);
                tmpPos.Y = (int)(tmpPos.Y * k);

                if (k1 < k2)
                {
                    tmpPos.X -= (int)((k2 - k1) * pictureBox1.Width / 2);
                }
                else
                {
                    tmpPos.Y -= (int)((k1 - k2) * pictureBox1.Height / 2);
                }

                if (lastPosition != null)
                {
                    var drawPoint1 = new Point(lastPosition.Value.X, lastPosition.Value.Y);
                    var drawPoint2 = new Point(tmpPos.X, tmpPos.Y);
                    var drawColor = Color.Black;
                    imageEditor.DrawLine(drawPoint1, drawPoint2, drawColor, 5);
                }

                lastPosition = tmpPos;
            }
            else
                lastPosition = null;
        }
        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lastPosition = null;
            }
        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var tmpPos = e.Location;
                var k1 = imageEditor.CurrentImage.Width * 1.0 / pictureBox1.Width;
                var k2 = imageEditor.CurrentImage.Height * 1.0 / pictureBox1.Height;
                var k = Math.Max(k1, k2);
                tmpPos.X = (int)(tmpPos.X * k);
                tmpPos.Y = (int)(tmpPos.Y * k);

                if (k1 < k2)
                {
                    tmpPos.X -= (int)((k2 - k1) * pictureBox1.Width / 2);
                }
                else
                {
                    tmpPos.Y -= (int)((k1 - k2) * pictureBox1.Height / 2);
                }

                lastPosition = tmpPos;
            }
        }
        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var SF = new SaveFileDialog();
            if (SF.ShowDialog() == DialogResult.OK)
            {
                imageEditor.CurrentImage.Save(SF.FileName);
            }
        }
    }
}
