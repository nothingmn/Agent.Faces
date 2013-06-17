using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class MarioTime : IFace      
    {
        public void RenderFace(Device device)
        {
            device.Border = new Border() {Thickness = 1, FooterHeight = 0, HeaderHeight = 0};

            device.Painter.PaintImage(Resources.GetBytes(Resources.BinaryResources.Mario_Time_1),
                                      Bitmap.BitmapImageType.Gif, new Point(0, 0));

            var font = device.Digital20;
            var hourPoint = new Point(52, 12);
            var minutePoint = new Point(96, 12);

            device.DrawingSurface.DrawText(device.Time.Hour, font, Color.Black, hourPoint.X, hourPoint.Y);
            device.DrawingSurface.DrawText(device.Time.Minute, font, Color.Black, minutePoint.X, minutePoint.Y);
        }

        public void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time, Device device) { }
    }
}
