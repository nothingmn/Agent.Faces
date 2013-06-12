using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class BareHands : IFace
    {
        public void RenderFace(Device device)
        {
            device.Border = new Border() { Thickness = 1, FooterHeight = 0, HeaderHeight = 0 };
            var time = DateTime.Now;
            device.Painter.DrawHourHand(Color.White, 1, time.Hour, time.Minute);
            device.Painter.DrawMinuteHand(Color.White, 1, time.Minute, time.Second);
            device.Painter.DrawSecondHand(Color.White, 1, time.Second);
        }

    }
}
