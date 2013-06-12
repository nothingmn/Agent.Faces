using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;

namespace SimpleFace
{
    public class Program : Microsoft.SPOT.Application
    {
        /// <summary>
        /// 1000 = 1 second
        /// </summary>
        private static int updateSpeed = 1000*5;

        public static void Main()
        {
            //setup our watch face, and wait until we can paint, etc.
            var face = new WatchFace();
            face.OnSetupCompleted += watchFace_OnSetupCompleted;
            face.OnPaint += watchFace_OnPaint;
            face.OnComplete += face_OnComplete;
            face.Start(updateSpeed);

        }

        private static void face_OnComplete(WatchFace face, Device device)
        {
            Debug.Print("Face paint complete");
        }

        private static void watchFace_OnPaint(WatchFace face, Device device)
        {

            Debug.Print("Face paint starting");
            //paintCenteredDate(device);
            paintBigDate(device);
        }

        private static void watchFace_OnSetupCompleted(WatchFace face, Device device)
        {
            device.Border = new Border() { Thickness = 1, FooterHeight = 0, HeaderHeight = 0 };
            //device.Border = new Border() {Thickness = 1, FooterHeight = device.NinaBFont.Height + 2, HeaderHeight = 10};
        }

        private static void paintBigDate(Device device)
        {
            //var text = device.Hour + "  " + device.DayOfWeek + "\n" + device.Minute + "  " + device.Month + " / " + device.Day;
            //device.Painter.PaintCentered(text, device.DefaultFont, Color.White);

            int defHeight = device.DefaultFont.Height;
            int defWidth = device.DefaultFont.CharWidth('0');
            int ninaHight = device.NinaBFont.Height;
            int ninaWidth = device.NinaBFont.CharWidth('0');

            string dow = device.DayOfWeek.ToLower();
            string time = device.Hour + ":" + device.Minute;
            string date = device.MonthNameShort.ToLower() + " " + device.Day + ", " + device.Year;

            device.DrawingSurface.DrawText(dow, device.NinaBFont, Color.White, 2, 1);

            device.Painter.PaintCentered(time, device.DefaultFont, Color.White);

            device.DrawingSurface.DrawText(date, device.NinaBFont, Color.White, Device.AgentSize - (ninaWidth * date.Length), defHeight * 2 + 2);

        }

        private static void paintCenteredDate(Device device)
        {
            device.Painter.PaintCentered(device.Hour24Minute, device.DefaultFont, Color.White);

            //print full date along the bottom
            device.Painter.PaintCentered(device.ShortDate, device.NinaBFont, Color.White,
                                         Device.AgentSize - device.Border.FooterHeight + 1);

            //print the day of the week in the footer
            //device.Painter.PaintCentered(device.DayOfWeek, device.NinaBFont, Color.White, Device.AgentSize - device.Border.FooterHeight + 1);

        }
    }
}