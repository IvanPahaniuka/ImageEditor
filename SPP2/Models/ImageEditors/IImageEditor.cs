using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SPP2.Models.ImageEditors
{
    public interface IImageEditor
    {
        event EventHandler CurrentImageChanged; 

        object CurrentImage { get; set; }

        IImageEditor Rotate(double angle);
        IImageEditor Saturate(double ratio);
        IImageEditor Lighten(double ratio);
        IImageEditor Contrast(double ratio);
        IImageEditor Resize(Size newSize);
        IImageEditor Scale(Size newSize);
        IImageEditor DrawRectangle(Rectangle rect, Color color);
        IImageEditor DrawLine(Point point1, Point point2, Color color, float thickness);


    }
}
