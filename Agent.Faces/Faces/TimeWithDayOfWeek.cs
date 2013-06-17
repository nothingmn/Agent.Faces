using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class TimeWithDayOfWeek : IFace
    {
        public void RenderFace(Device device)
        {
            device.Border = new Border() { Thickness = 1, FooterHeight = 1, HeaderHeight = 0 };
            Font f = device.NinaBFont;
            device.Painter.PaintCentered(device.Time.Hour24Minute + " " + device.Time.AMPM, f, Color.White);

            device.Painter.PaintCentered(device.Time.DayOfWeek, f, Color.White, Device.AgentSize - f.Height);

        }
        public void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time, Device device) { }

    }
}