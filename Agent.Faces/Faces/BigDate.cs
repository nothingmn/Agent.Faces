using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class BigDate : IFace      
    {
        public void RenderFace(Device device)
        {
            device.Border = new Border() { Thickness = 1, FooterHeight = 0, HeaderHeight = 0 };
            string dow = device.Time.DayOfWeek.ToLower();
            string time = device.Time.Hour + ":" + device.Time.Minute;
            string date = device.Time.MonthNameShort.ToLower() + " " + device.Time.Day + ", " + device.Time.Year;

            int defHeight = device.DefaultFont.Height;
            int ninaWidth = device.Painter.MeasureString(date, device.NinaBFont);


            device.DrawingSurface.DrawText(dow, device.NinaBFont, Color.White, 2, 1);

            device.Painter.PaintCentered(time, device.DefaultFont, Color.White);

            device.DrawingSurface.DrawText(date, device.NinaBFont, Color.White, Device.AgentSize - ninaWidth, defHeight*2 + 2);
        }

    }
}
