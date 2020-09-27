using SPP2.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace SPP2.Models.ImageEditors.Generic
{
    public class ImageEditor : IImageEditor<Image>
    {
        public event EventHandler CurrentImageChanged;

        private Image currentImage;

        public Image CurrentImage
        {
            get => currentImage;
            set
            {
                currentImage = value;
                OnCurrentImageChanged();
            }
        }

        public ImageEditor()
            : this(default)
        {
        }
        public ImageEditor(Image image)
        {
            CurrentImage = image;
        }
            
        public IImageEditor<Image> Contrast(double ratio)
        {
            if (CurrentImage == null)
                return this;

            var NewBitmap = new Bitmap(CurrentImage);
            var data = NewBitmap.LockBits(
                new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
                ImageLockMode.ReadWrite,
                NewBitmap.PixelFormat);
            int Height = NewBitmap.Height;
            int Width = NewBitmap.Width;

            var contrast_lookup = new byte[256];
            double newValue = 0;
            double c = (100.0 + ratio) / 100.0;

            c *= c;

            for (int i = 0; i < 256; i++)
            {
                newValue = (double)i;
                newValue /= 255.0;
                newValue -= 0.5;
                newValue *= c;
                newValue += 0.5;
                newValue *= 255;

                if (newValue < 0)
                    newValue = 0;
                if (newValue > 255)
                    newValue = 255;
                contrast_lookup[i] = (byte)newValue;
            }

            unsafe
            {
                for (int y = 0; y < Height; ++y)
                {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < Width; ++x)
                    {
                        row[columnOffset] = contrast_lookup[row[columnOffset]];
                        row[columnOffset + 1] = contrast_lookup[row[columnOffset + 1]];
                        row[columnOffset + 2] = contrast_lookup[row[columnOffset + 2]];
                        columnOffset += 4;
                    }
                }
            }

            NewBitmap.UnlockBits(data);

            CurrentImage = NewBitmap;
           

            return this;
        }
        public IImageEditor<Image> Lighten(double ratio)
        {
            if (CurrentImage == null)
                return this;

            var NewBitmap = new Bitmap(CurrentImage);
            var data = NewBitmap.LockBits(
                new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
                ImageLockMode.ReadWrite,
                NewBitmap.PixelFormat);
            int Height = NewBitmap.Height;
            int Width = NewBitmap.Width;

            ratio /= 100.0;

            unsafe
            {
                for (int y = 0; y < Height; ++y)
                {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < Width; ++x)
                    {
                        var color = Color.FromArgb(
                            row[columnOffset + 3], 
                            row[columnOffset + 2], 
                            row[columnOffset + 1], 
                            row[columnOffset]);
                        var colorHSB = color.ToAhsb();

                        colorHSB.B += (float)ratio;
                        if (colorHSB.B > 1)
                            colorHSB.B = 1;
                        if (colorHSB.B < 0)
                            colorHSB.B = 0;

                        color = colorHSB.ToArgb();

                        row[columnOffset + 3] = color.A;
                        row[columnOffset + 2] = color.R;
                        row[columnOffset + 1] = color.G;
                        row[columnOffset] = color.B;

                        columnOffset += 4;
                    }
                }
            }

            NewBitmap.UnlockBits(data);

            CurrentImage = NewBitmap;

            return this;
        }
        public IImageEditor<Image> Resize(Size newSize)
        {
            if (CurrentImage == null)
                return this;

            var newBitmap = new Bitmap(newSize.Width, newSize.Height);
            var graphics = Graphics.FromImage(newBitmap);
            var point = new Point(
                (newSize.Width - CurrentImage.Width) / 2, 
                (newSize.Height - CurrentImage.Height) / 2);
            graphics.DrawImage(CurrentImage, point);
            CurrentImage = newBitmap;

            return this;
        }
        public IImageEditor<Image> Rotate(double angle)
        {
            int angleInt = Convert.ToInt32(angle);
            if (CurrentImage == null || angleInt % 90 != 0)
                return this;

            var newImage = (Image)CurrentImage.Clone();
            angleInt %= 360;
            angleInt -= (angleInt / 270) * 360;
            switch (angleInt)
            {
                case 180:
                case -180:
                    newImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 90:
                    newImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case -90:
                    newImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
            }
            CurrentImage = newImage;

            return this;
        }
        public IImageEditor<Image> Saturate(double ratio)
        {
            if (CurrentImage == null)
                return this;

            var NewBitmap = new Bitmap(CurrentImage);
            var data = NewBitmap.LockBits(
                new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
                ImageLockMode.ReadWrite,
                NewBitmap.PixelFormat);
            int Height = NewBitmap.Height;
            int Width = NewBitmap.Width;

            ratio /=  100.0;

            unsafe
            {
                for (int y = 0; y < Height; ++y)
                {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < Width; ++x)
                    {
                        var color = Color.FromArgb(
                            row[columnOffset + 3],
                            row[columnOffset + 2],
                            row[columnOffset + 1],
                            row[columnOffset]);
                        var colorHSB = color.ToAhsb();

                        colorHSB.S += (float)ratio;

                        if (colorHSB.S > 1)
                            colorHSB.S = 1;
                        if (colorHSB.S < 0)
                            colorHSB.S = 0;

                        color = colorHSB.ToArgb();

                        row[columnOffset + 3] = color.A;
                        row[columnOffset + 2] = color.R;
                        row[columnOffset + 1] = color.G;
                        row[columnOffset] = color.B;

                        columnOffset += 4;
                    }
                }
            }

            NewBitmap.UnlockBits(data);

            CurrentImage = NewBitmap;

            return this;
        }
        public IImageEditor<Image> Scale(Size newSize)
        {
            if (CurrentImage == null)
                return this;

            CurrentImage = new Bitmap(CurrentImage, newSize);

            return this;
        }
        public IImageEditor<Image> DrawRectangle(Rectangle rect, Color color)
        {
            if (CurrentImage == null)
                return this;

            var bitmap = CurrentImage as Bitmap;
            if (bitmap == null)
                bitmap = new Bitmap(CurrentImage);

            var graphics = Graphics.FromImage(bitmap);
            graphics.DrawRectangle(new Pen(color), rect);
            CurrentImage = bitmap;

            return this;
        }
        public IImageEditor<Image> DrawLine(Point point1, Point point2, Color color, float thickness)
        {
            if (CurrentImage == null)
                return this;

            var bitmap = CurrentImage as Bitmap;
            if (bitmap == null)
                bitmap = new Bitmap(CurrentImage);

            var graphics = Graphics.FromImage(bitmap);
            graphics.DrawLine(new Pen(color, thickness), point1, point2);
            CurrentImage = bitmap;

            return this;
        }


        private void OnCurrentImageChanged()
        {
            CurrentImageChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    
}
