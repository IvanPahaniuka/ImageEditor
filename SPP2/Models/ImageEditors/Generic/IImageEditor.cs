using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SPP2.Models.ImageEditors.Generic
{
    public interface IImageEditor<T> : IImageEditor
    {
        new T CurrentImage { get; set; }

        new IImageEditor<T> Rotate(double angle);
        new IImageEditor<T> Saturate(double ratio);
        new IImageEditor<T> Lighten(double ratio);
        new IImageEditor<T> Contrast(double ratio);
        new IImageEditor<T> Resize(Size newSize);
        new IImageEditor<T> Scale(Size newSize);
        new IImageEditor<T> DrawRectangle(Rectangle rect, Color color);
        new IImageEditor<T> DrawLine(Point point1, Point point2, Color color, float thickness);

        #region IImageEditor
        object IImageEditor.CurrentImage
        {
            get => CurrentImage;
            set => CurrentImage = (T)value;
        }

        IImageEditor IImageEditor.Rotate(double angle)
        {
            return Rotate(angle);
        }
        IImageEditor IImageEditor.Saturate(double ratio)
        {
            return Saturate(ratio);
        }
        IImageEditor IImageEditor.Lighten(double ratio)
        {
            return Lighten(ratio);
        }
        IImageEditor IImageEditor.Contrast(double ratio)
        {
            return Contrast(ratio);
        }
        IImageEditor IImageEditor.Resize(Size newSize)
        {
            return Resize(newSize);
        }
        IImageEditor IImageEditor.Scale(Size newSize)
        {
            return Scale(newSize);
        }
        IImageEditor IImageEditor.DrawRectangle(Rectangle rect, Color color)
        {
            return DrawRectangle(rect, color);
        }
        IImageEditor IImageEditor.DrawLine(Point point1, Point point2, Color color, float thickness)
        {
            return DrawLine(point1, point2, color, thickness);
        }
        #endregion
    }
}
