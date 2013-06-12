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
            get { return SystemMetrics.ScreenHeight; }
        }

        public static int ScreenWidth
        {
            get { return SystemMetrics.ScreenWidth; }
        }

        public static int AgentSize
        {
            get { return 128; }
        }

        public DateTime Time { get; set; }

        public string AMPM
        {
            get
            {
                if (Time.Hour >= 12) return "PM";
                return "AM";
            }
        }

        public string HourMinute
        {
            get { return Hour + ":" + Minute; }
        }

        public string Hour24Minute
        {
            get { return Hour24 + ":" + Minute; }
        }

        public string HourMinuteSecond
        {
            get { return Hour + ":" + Minute + ":" + Second; }
        }

        public string Hour24MinuteSecond
        {
            get { return Hour24 + ":" + Minute + ":" + Second; }
        }

        public string Month
        {
            get { return Time.Month.ToString(); }
        }

        public string Day
        {
            get { return Time.Day.ToString(); }
        }

        public string Year
        {
            get { return Time.Year.ToString(); }
        }
        public string MonthName
        {
            get { return System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames[(int)Time.Month]; }
        }
        public string MonthNameShort
        {
            get { return System.Globalization.DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames[(int)Time.Month]; }
        }
        public string DayOfWeek
        {
            get { return System.Globalization.DateTimeFormatInfo.CurrentInfo.DayNames[(int) Time.DayOfWeek]; }
        }

        public string ShortDate
        {
            get { return Year + "/" + Month + "/" + Day; }
        }


        public string Hour
        {
            get
            {
                Time = DateTime.Now;
                int hour = Time.Hour;
                if (hour > 12) hour = hour - 12;
                var h = hour.ToString();
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

        private object _lock = new object();
        private Bitmap _DrawingSurface;
        private Painter _painter;

        public Painter Painter
        {
            get { return _painter; }
        }

        public Bitmap DrawingSurface
        {
            get
            {
                lock (_lock)
                {
                    if (_DrawingSurface == null)
                    {
                        _DrawingSurface = new Bitmap(ScreenWidth, ScreenHeight);
                        _painter = new Painter(_DrawingSurface);
                    }
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

        public static Point Center
        {
            get { return new Point(64, 64); }
        }

        private Font _Candara48NPSSp = Resources.GetFont(Resources.FontResources.Candara48NPSSp);
        public Font DefaultFont
        {
            get { return _Candara48NPSSp; }
        }
        private Font _medium = Resources.GetFont(Resources.FontResources.BookAntiquaNumbers);

        public Font MediumFont
        {
            get { return _medium; }
        }
    }
}