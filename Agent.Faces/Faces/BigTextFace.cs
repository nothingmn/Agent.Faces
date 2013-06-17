using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

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
            TextTime hourLiteralTime = TextTime.TextHourLiteral(device.Time.CurrentTime.Hour);
            TextTime timeSepTime = TextTime.TextTimeSeperator();
            TextTime minuteTime = TextTime.TextMinute(device.Time.CurrentTime.Minute);
            TextTime hourFriendlyTime = TextTime.TextHourFriendly(device.Time.CurrentTime.Hour);

            if (renderSep)
            {
                if (device.Time.CurrentTime.Minute > 0)
                {
                    device.DrawingSurface.DrawText(hourLiteralTime.Text, Resources.GetFont((Resources.FontResources)hourLiteralTime.FontHour), Color.White, 1, 20);
                    device.DrawingSurface.DrawText(timeSepTime.Text, Resources.GetFont((Resources.FontResources)timeSepTime.FontMinute), Color.White, 1, 50);
                    device.DrawingSurface.DrawText(minuteTime.Text, Resources.GetFont((Resources.FontResources)minuteTime.FontMinute), Color.White, 1, 78);
                }
                else
                {

                    device.DrawingSurface.DrawText(hourFriendlyTime.Text, Resources.GetFont((Resources.FontResources)hourFriendlyTime.FontHour), Color.White, 1,
                                                   (Device.AgentSize/2) - (font.Height/2));

                }
            }
            else
            {
                device.DrawingSurface.DrawText(hourLiteralTime.Text, Resources.GetFont((Resources.FontResources)hourLiteralTime.FontHour), Color.White, 1, 25);
                device.DrawingSurface.DrawText(minuteTime.Text, Resources.GetFont((Resources.FontResources)minuteTime.FontMinute), Color.White, 1, 65);

            }
        }

        public void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time, Device device)
        {
        }
    }
}