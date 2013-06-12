using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class SimpleDigitalFace : IFace      
    {
        public void RenderFace(Device device)
        {
            device.Border = new Border() { Thickness = 1, FooterHeight = 0, HeaderHeight = 0 };
            string time = (device.Time.HourMinute + " " + device.Time.AMPM).ToLower();

            device.Painter.PaintCentered(time, device.Digital20, Color.White);
        }

    }
}
