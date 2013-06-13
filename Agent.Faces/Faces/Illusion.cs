using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class Illusion : IFace      
    {
        public void RenderFace(Device device)
        {
            device.Border = new Border() {Thickness = 1, FooterHeight = 0, HeaderHeight = 0};

            device.Painter.PaintImage(Resources.GetBytes(Resources.BinaryResources.App_Faces_Optical_Illusion_SquareWave),
                                      Bitmap.BitmapImageType.Gif, new Point(0, 0));

            var font = device.Digital20;
            var hourPoint = new Point(52, 12);
            var minutePoint = new Point(96, 12);

            device.DrawingSurface.DrawText(device.Time.Hour, font, Color.Black, hourPoint.X, hourPoint.Y);
            device.DrawingSurface.DrawText(device.Time.Minute, font, Color.Black, minutePoint.X, minutePoint.Y);
        }

        public void OnButtonPress(object sender, ButtonEventArgs args, Button button, Device device) { }
    }
}
