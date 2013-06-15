using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class BigTime : IFace
    {
        public BigTime()
        {

        }

        public void RenderFace(Device device)
        {
            device.Border = new Border() {Thickness = 1, FooterHeight = 0, HeaderHeight = 0};
            var font = device.Courier72Bold;
            string hour = device.Time.Hour;
            if (hour.Length == 1) hour = "0" + hour;
            device.DrawingSurface.DrawText(hour, font, Color.White, 5, -20);

            device.DrawingSurface.DrawText(device.Time.Minute, font, Color.White, 5, 40);

        }

        public void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time, Device device)
        {
        }
    }
}