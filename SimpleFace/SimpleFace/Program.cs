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
        private static int updateSpeed = 1000*1;

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
            //paintBigDate(device);
            //paintBinaryWatch(device);
            //hatWithTime(device);
            //bareHands(device);

            //goMarioGo(device);

            simpleDigital(device);

        }

        private static void watchFace_OnSetupCompleted(WatchFace face, Device device)
        {
            device.Border = new Border() {Thickness = 1, FooterHeight = 0, HeaderHeight = 0};
            //device.Border = new Border() {Thickness = 1, FooterHeight = device.NinaBFont.Height + 2, HeaderHeight = 10};
        }
        private static void simpleDigital(Device device)
        {
            string time = (device.HourMinute + " " + device.AMPM).ToLower();

            device.Painter.PaintCentered(time, device.Digital20, Color.White);
        }
        private static void goMarioGo(Device device)
        {
            string time = (device.HourMinute + " " + device.AMPM).ToLower();
            device.Painter.PaintCentered(Resources.GetBytes(Resources.BinaryResources.Mario), Bitmap.BitmapImageType.Gif);

            int x = (Device.AgentSize / 2) - (device.Painter.MeasureString(time, device.NinaBFont) / 2);
            int y = Device.AgentSize - device.NinaBFont.Height + 1;
            device.DrawingSurface.DrawText(time, device.NinaBFont, Color.Black, x, y);
        }

        private static void bareHands(Device device)
        {
            var time = DateTime.Now;
            device.Painter.DrawHourHand(Color.White, 1, time.Hour, time.Minute);
            device.Painter.DrawMinuteHand(Color.White, 1, time.Minute, time.Second);
            device.Painter.DrawSecondHand(Color.White, 1, time.Second);

        }

        private static void hatWithTime(Device device)
        {
            var img = new Bitmap(Resources.GetBytes(Resources.BinaryResources.hat), Bitmap.BitmapImageType.Gif);
            device.DrawingSurface.DrawImage((Device.AgentSize/2) - (img.Width/2), 1, img, 0, 0, img.Width, img.Height);

            device.Painter.PaintCentered(device.HourMinute, device.DefaultFont, Color.White);
        }


        private static void paintBinaryWatch(Device device)
        {

            var h_eight = " - ";
            var h_four = " - ";
            var h_two = " - ";
            var h_one = " - ";
            int hour = Convert.ToInt32(device.Hour);

            if (hour >= 8)
            {
                h_eight = " 8 ";
                hour -= 8;
            }
            Debug.Print(hour.ToString());
            if (hour >= 4)
            {
                h_four = " 4 ";
                hour -= 4;
            }
            Debug.Print(hour.ToString());
            if (hour >= 2)
            {
                h_two = " 2 ";
                hour -= 2;
            }
            Debug.Print(hour.ToString());
            if (hour >= 1)
            {
                h_one = " 1 ";
                hour -= 1;
            }
            Debug.Print(hour.ToString());
            var assembled = (h_eight + h_four + h_two + h_one).Trim();
            Debug.Print(assembled);

            var m_thirtytwo = " - ";
            var m_sixteen = " - ";
            var m_eight = " - ";
            var m_four = " - ";
            var m_two = " - ";
            var m_one = " - ";
            int min = DateTime.Now.Minute;
            if (min >= 32)
            {
                m_thirtytwo = " 32 ";
                min -= 32;
            }
            if (min >= 16)
            {
                m_sixteen = " 16 ";
                min -= 16;
            }
            if (min >= 8)
            {
                m_eight = " 8 ";
                min -= 8;
            }
            if (min >= 4)
            {
                m_four = " 4 ";
                min -= 4;
            }
            if (min >= 2)
            {
                m_two = " 2 ";
                min -= 2;
            }
            if (min >= 1)
            {
                m_one = " 1 ";
                min -= 1;
            }
            var minutes = (m_thirtytwo + m_sixteen + m_eight + m_four + m_two + m_one).Trim();
            int top = (Device.AgentSize/2) - device.NinaBFont.Height*3;

            device.DrawingSurface.DrawText("Hour:", device.NinaBFont, Color.White, 2, top);
            top = top + device.NinaBFont.Height + 1;

            device.Painter.PaintCentered(assembled, device.NinaBFont, Color.White, top);

            top = top + device.NinaBFont.Height*2 + 1;
            device.DrawingSurface.DrawText("Minute:", device.NinaBFont, Color.White, 2, top);

            top = top + device.NinaBFont.Height + 1;
            device.Painter.PaintCentered(minutes, device.NinaBFont, Color.White, top);

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

            device.DrawingSurface.DrawText(date, device.NinaBFont, Color.White,
                                           Device.AgentSize - (ninaWidth*date.Length), defHeight*2 + 2);

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