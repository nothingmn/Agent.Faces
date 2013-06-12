using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;

namespace SimpleFace
{
    public class Device
    {
        public Device()
        {
            Border = new Border();
        }

        public Border Border { get; set; }

        public static int ScreenHeight
        {
            get { return 128; } // SystemMetrics.ScreenHeight;
        }

        public DateTime Time { get; set; }

        public string HourMinute { get { return Hour + ":" + Minute; } }
        public string Hour24Minute { get { return Hour24 + ":" + Minute; } }
        public string HourMinuteSecond { get { return Hour + ":" + Minute + ":" + Second; } }
        public string Hour24MinuteSecond { get { return Hour24 + ":" + Minute + ":" + Second; } }
        

        public string Hour 
        {
            get
            {
                Time = DateTime.Now;
                int hour = Time.Hour;
                if (hour > 12) hour = hour - 12;
                var h = hour.ToString();
                if (h.Length == 1) h = "0" + h;
                return h;
            }
        }
        public string Hour24
        {
            get
            {
                Time = DateTime.Now;
                var hour = Time.Hour.ToString();
                if (hour.Length == 1) hour = "0" + hour;
                return hour;
            }
        }
        public string Minute
        {
            get
            {
                Time = DateTime.Now;
                var min = Time.Minute.ToString();
                if (min.Length == 1) min = "0" + min;
                return min;

            }
        }
        public string Second
        {
            get
            {
                Time = DateTime.Now;
                var seconds = Time.Second.ToString();
                if (seconds.Length == 1) seconds = "0" + seconds;
                return seconds;
            }
        }

        public static int ScreenWidth
        {
            get { return 128; } // SystemMetrics.ScreenWidth; }
        }

        private object _lock = new object();
        private Bitmap _DrawingSurface;

        public Bitmap DrawingSurface
        {
            get
            {
                lock (_lock)
                {
                    if (_DrawingSurface == null) _DrawingSurface = new Bitmap(ScreenWidth, ScreenHeight);
                }
                return _DrawingSurface;
            }
        }

        private Font _SmallFont = Resources.GetFont(Resources.FontResources.small);

        public Font SmallFont
        {
            get { return _SmallFont; }
        }

        private Font _NinaBFont = Resources.GetFont(Resources.FontResources.NinaB);

        public Font NinaBFont
        {
            get { return _NinaBFont; }
        }

        private Font _BookAntiquaNumbers = Resources.GetFont(Resources.FontResources.BookAntiquaNumbers);

        public Font DefaultFont
        {
            get { return _BookAntiquaNumbers; }
        }
    }
}