using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class SunriseAndSet : IFace      
    {
        public void RenderFace(Device device)
        {
            device.Border = new Border() { Thickness = 1, FooterHeight = 0, HeaderHeight = 0 };

            device.Painter.PaintCentered(device.Time.HourMinuteAMPM, device.Digital20, Color.White);

            var sunData = device.Time.Suntimes(device.Location);
            if (sunData.Valid)
            {
                var rise = new Time();
                rise.CurrentTime = sunData.Sunrise;
                var sunMsg = "Rise: " + rise.HourMinute;

                var set = new Time();
                set.CurrentTime = sunData.Sunset;
                sunMsg += " | Set: " + set.HourMinute;
                device.Painter.PaintBottomCenter(sunMsg, device.SmallFont, Color.White);
            }


        }
        public void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time, Device device) { }

    }
}
