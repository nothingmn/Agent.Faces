using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class BigHands : IFace
    {
        private Bitmap img = new Bitmap(Resources.GetBytes(Resources.BinaryResources.WatchFaceFromScratch),
                                        Bitmap.BitmapImageType.Gif);

        public void RenderFace(Device device)
        {
            device.DrawingSurface.DrawImage(0, 0, img, 0, 0, img.Width, img.Height);

            var text = "agent";
            Point textLocation = new Point(
                Device.Center.X - (device.Painter.MeasureString(text, device.SmallFont)/2), Device.Center.Y - 25);
            device.DrawingSurface.DrawText(text, device.SmallFont, Color.White, textLocation.X, textLocation.Y);

            var date = device.Time.MonthNameShort + " " + device.Time.Day;
            Point dateLocation = new Point(
                Device.Center.X - (device.Painter.MeasureString(date, device.SmallFont)/2), Device.Center.Y + 20);
            device.DrawingSurface.DrawText(date, device.SmallFont, Color.White, dateLocation.X, dateLocation.Y);



            device.Painter.PaintThickHands(device, true, true, false);
            
            
            
            //device.Border = new Border() { Thickness = 1, FooterHeight = 0, HeaderHeight = 0 };

        }


        public void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time,
                                  Device device)
        {
        }
    }
}