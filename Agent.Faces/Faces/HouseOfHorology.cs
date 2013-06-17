using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class HouseOfHorology : IFace      
    {
        
        public void RenderFace(Device device)
        {
            device.Border = new Border() {Thickness = 1, FooterHeight = 0, HeaderHeight = 0};

            device.Painter.PaintImage(Resources.GetBytes(Resources.BinaryResources.hoh),
                                      Bitmap.BitmapImageType.Gif, new Point(0, 0));

            var font = device.Digital12;
            device.Painter.PaintCentered(device.Time.HourMinute + " ", font, Color.White);
            int top = Device.AgentSize - device.SmallFont.Height - 2;
            var monthDay = device.Time.MonthNameShort + " " + device.Time.Day;
            int width = device.Painter.MeasureString(monthDay, device.SmallFont);
            device.DrawingSurface.DrawText(monthDay, device.SmallFont, Color.White, Device.AgentSize - 2 - width, top);
            device.DrawingSurface.DrawText(device.Time.DayOfWeek, device.SmallFont, Color.White, 2, top);

        }

        public void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time, Device device)
        {
            if (direction == ButtonDirection.Up)
            {
                if (button == Buttons.Top)
                {
                    
                }
            }

        }
    }
}
