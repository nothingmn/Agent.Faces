using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class DigitalTimeZones : IFace
    {
        private int offset = (DateTime.Now.Hour - DateTime.UtcNow.Hour) - 24;
        private int staticOffset = (DateTime.Now.Hour - DateTime.UtcNow.Hour) - 24;

        public void RenderFace(Device device)
        {


            device.Border = new Border() {Thickness = 1, FooterHeight = 0, HeaderHeight = 0};
            string time = (device.Time.HourMinute + " " + device.Time.AMPM).ToLower();

            device.Painter.PaintCentered(time, device.Digital20, Color.White);

            if (offset != staticOffset)
            {

                Debug.Print(offset.ToString());
                var t = System.DateTime.UtcNow.AddHours(offset);
                var h = t.Hour;
                if (h > 12) h = h - 12;
                if (h == 0) h = 12;
                string sep = "";
                if (offset >= 0) sep = "+";

                var m = t.Minute.ToString();
                if (m.Length == 1) m = "0" + m;

                var amPm = (t.Hour >= 12) ? "PM" : "AM";
                string offsetTime =
                    (h + ":" + m + " " + amPm + "  UTC" + sep + offset + "").ToLower();

                device.Painter.PaintBottomCenter(offsetTime, device.NinaBFont, Color.White);
            }
        }

        public void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time,
                                  Device device)
        {
            if (direction == ButtonDirection.Up)
            {
                if (button == Buttons.Top)
                {
                    offset++;
                    if (offset > 13) offset = 13;
                }
                if (button == Buttons.Bottom)
                {
                    offset--;
                    if (offset < -12) offset = -12;
                }




                Debug.Print(offset.ToString());
            }
        }
    }
}