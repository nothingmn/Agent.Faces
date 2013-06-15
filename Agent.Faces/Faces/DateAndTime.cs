using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class DateAndTime : IFace      
    {
        public void RenderFace(Device device)
        {
            device.Border = new Border() { Thickness = 1, FooterHeight = 0, HeaderHeight = 0 };
            device.Painter.PaintCentered(device.Time.Hour24Minute, device.DefaultFont, Color.White);

            //print full date along the bottom
            device.Painter.PaintCentered(device.Time.ShortDate, device.NinaBFont, Color.White, Device.AgentSize - device.NinaBFont.Height);
        }
        public void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time, Device device) { }

    }
}
