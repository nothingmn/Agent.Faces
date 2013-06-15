using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{

    /// <summary>
    /// Minute rotating around the Hour in the middle
    /// </summary>
    public class Lunar : IFace
    {
        public void RenderFace(Device device)
        {

            var font = device.Digital20;

            device.Border = new Border() {Thickness = 1, FooterHeight = 0, HeaderHeight = 0};

            var minutePoint = device.Painter.MinuteHandLocation( device.Time.CurrentTime.Minute,
                                                            device.Time.CurrentTime.Second);

            var MinuteWidth = device.Painter.MeasureString(device.Time.Minute, font);
            var MinuteHeight = font.Height;
            var rad = (MinuteHeight > MinuteWidth) ? MinuteHeight : MinuteWidth;
            rad = rad/2;
            int radius = 40 - (rad/2);

            var x = minutePoint.X - MinuteWidth / 2;
            var y = minutePoint.Y - MinuteHeight / 2;
            //inner hour larger circle
            device.DrawingSurface.DrawEllipse(Color.White, 1, Device.Center.X, Device.Center.Y, radius, radius,
                                              Color.White, 0,
                                              0, Color.White, 0, 0, 0);

            //outer minute smaller circle
            var padding = rad + 3;
            device.DrawingSurface.DrawEllipse(Color.White, 1, minutePoint.X, minutePoint.Y, padding, padding, Color.Black, 0, 0,
                                              Color.Black,0 , 0, 0);

            //hour text in the center
            device.Painter.PaintCentered(device.Time.Hour, device.DefaultFont, Color.White);

            //minute text as the moon orbiting
            device.DrawingSurface.DrawText(device.Time.Minute, font, Color.White, x, y);
        }
        public void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time, Device device) { }

    }
}
