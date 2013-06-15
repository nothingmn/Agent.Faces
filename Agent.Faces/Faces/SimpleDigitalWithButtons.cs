using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class SimpleDigitalWithButtons : IFace
    {
        private bool buttonWasPressed = false;

        public void RenderFace(Device device)
        {
            device.Border = new Border() {Thickness = 1, FooterHeight = 0, HeaderHeight = 0};
            string time = (device.Time.HourMinute + " " + device.Time.AMPM).ToLower();
            device.Painter.PaintCentered(time, device.Digital20, Color.White);
            if (buttonWasPressed) PressedRender(device);
        }

        public void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time, Device device)
        {
            buttonWasPressed = !buttonWasPressed;

            if (buttonWasPressed)
            {
                PressedRender(device);
            }
            else
            {
                device.DrawingSurface.DrawRectangle(Color.Black, 1, device.Border.Thickness+1,
                                                    Device.AgentSize - device.SmallFont.Height,
                                                    Device.AgentSize - (device.Border.Thickness*2),
                                                    device.SmallFont.Height, 0, 0, Color.Black, 0, 0, Color.Black, 0, 0,
                                                    255);
            }
            device.DrawingSurface.Flush();

        }

        private void PressedRender(Device device)
        {
            device.Painter.PaintBottomCenter(device.Time.DayOfWeek, device.SmallFont, Color.White);

        }
    }
}