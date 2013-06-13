using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class BigTextFace : IFace
    {
        public BigTextFace()
        {

        }

        public void RenderFace(Device device)
        {
            device.Border = new Border() {Thickness = 1, FooterHeight = 0, HeaderHeight = 0};
            var font = device.Buxton20;
            var renderSep = (device.Time.CurrentTime.Minute < 10);

            if (renderSep)
            {
                if (device.Time.CurrentTime.Minute > 0)
                {
                    device.DrawingSurface.DrawText(device.Time.TextHourLiteral, font, Color.White, 1, 20);
                    device.DrawingSurface.DrawText(device.Time.TextTimeSeperator, font, Color.White, 1, 50);
                    device.DrawingSurface.DrawText(device.Time.TextMinute, font, Color.White, 1, 78);
                }
                else
                {

                    device.DrawingSurface.DrawText(device.Time.TextHourFriendly, font, Color.White, 1,
                                                   (Device.AgentSize/2) - (font.Height/2));

                }
            }
            else
            {
                device.DrawingSurface.DrawText(device.Time.TextHourLiteral, font, Color.White, 1, 25);
                device.DrawingSurface.DrawText(device.Time.TextMinute, font, Color.White, 1, 65);

            }
        }

        public void OnButtonPress(object sender, ButtonEventArgs args, Button button, Device device)
        {
        }
    }
}