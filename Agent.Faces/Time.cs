using System;
using Microsoft.SPOT;

namespace Agent.Faces
{
    public class Time
    {

        private string[] Numbers = new string[63];

        public Time()
        {
            CurrentTime = DateTime.Now;
            #region TextNumbers
            Numbers[0] = "zero";
            Numbers[1] = "one";
            Numbers[2] = "two";
            Numbers[3] = "three";
            Numbers[4] = "four";
            Numbers[5] = "five";
            Numbers[6] = "six";
            Numbers[7] = "seven";
            Numbers[8] = "eight";
            Numbers[9] = "nine";
            Numbers[10] = "ten";
            Numbers[11] = "eleven";
            Numbers[12] = "twelve";
            Numbers[13] = "thirteen";
            Numbers[14] = "fourteen";
            Numbers[15] = "fifteen";
            Numbers[16] = "sixteen";
            Numbers[17] = "seventeen";
            Numbers[18] = "eighteen";
            Numbers[19] = "nineteen";
            Numbers[20] = "twenty";
            Numbers[21] = "twenty one";
            Numbers[22] = "twenty two";
            Numbers[23] = "twenty three";
            Numbers[24] = "twenty four";
            Numbers[25] = "twenty five";
            Numbers[26] = "twenty six";
            Numbers[27] = "twenty seven";
            Numbers[28] = "twenty eight";
            Numbers[29] = "twenty nine";
            Numbers[30] = "thirty";
            Numbers[31] = "thirty one";
            Numbers[32] = "thirty two";
            Numbers[33] = "thirty three";
            Numbers[34] = "thirty four";
            Numbers[35] = "thirty five";
            Numbers[36] = "thirty six";
            Numbers[37] = "thirty seven";
            Numbers[38] = "thirty eight";
            Numbers[39] = "thirty nine";
            Numbers[40] = "fourty";
            Numbers[41] = "fourty one";
            Numbers[42] = "fourty two";
            Numbers[43] = "fourty three";
            Numbers[44] = "fourty four";
            Numbers[45] = "fourty five";
            Numbers[46] = "fourty six";
            Numbers[47] = "fourty seven";
            Numbers[48] = "fourty eight";
            Numbers[49] = "fourty nine";
            Numbers[50] = "fifty";
            Numbers[51] = "fifty one";
            Numbers[52] = "fifty two";
            Numbers[53] = "fifty three";
            Numbers[54] = "fifty four";
            Numbers[55] = "fifty five";
            Numbers[56] = "fifty six";
            Numbers[57] = "fifty seven";
            Numbers[58] = "fifty eight";
            Numbers[59] = "fifty nine";
            Numbers[60] = "oh";
            Numbers[61] = "midnight";
            Numbers[62] = "noon";

            #endregion
        }

        public string TextHourFriendly
        {
            get
            {
                int hour = Convert.ToInt32(Hour);
                if (CurrentTime.Hour == 0)
                {
                    hour = 61;
                } else if (CurrentTime.Hour == 12)
                {
                    hour = 62;
                } 
                return Numbers[hour];
            }
        }
        public string TextHourLiteral
        {
            get
            {
                int hour = Convert.ToInt32(Hour);
                return Numbers[hour];
            }
        }
        public string TextMinute
        {
            get
            {
                
                return Numbers[CurrentTime.Minute];
            }
        }
        public string TextTimeSeperator
        {
            get { return Numbers[60]; }
        }
        public DateTime CurrentTime { get; set; }

        public string AMPM
        {
            get
            {
                if (CurrentTime.Hour >= 12) return "PM";
                return "AM";
            }
        }

        public string HourMinute
        {
            get { return Hour + ":" + Minute; }
        }

        public string HourMinuteAMPM
        {
            get { return Hour + ":" + Minute + " " + AMPM; }
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
            get { return CurrentTime.Month.ToString(); }
        }

        public string Day
        {
            get { return CurrentTime.Day.ToString(); }
        }

        public string Year
        {
            get { return CurrentTime.Year.ToString(); }
        }

        public string MonthName
        {
            get { return System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames[(int) CurrentTime.Month]; }
        }

        public string MonthNameShort
        {
            get { return System.Globalization.DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames[(int) CurrentTime.Month]; }
        }

        public string DayOfWeek
        {
            get { return System.Globalization.DateTimeFormatInfo.CurrentInfo.DayNames[(int) CurrentTime.DayOfWeek]; }
        }

        public string ShortDate
        {
            get { return Year + "/" + Month + "/" + Day; }
        }


        public string Hour
        {
            get
            {
                int hour = CurrentTime.Hour;
                if (hour == 0) hour = 12;
                if (hour > 12) hour = hour - 12;
                var h = hour.ToString();
                return h;
            }
        }

        public string Hour24
        {
            get
            {
                var hour = CurrentTime.Hour.ToString();
                if (hour.Length == 1) hour = "0" + hour;
                return hour;
            }
        }

        public string Minute
        {
            get
            {
                var min = CurrentTime.Minute.ToString();
                if (min.Length == 1) min = "0" + min;
                return min;

            }
        }


        public Suntime Suntimes(Location location)
        {
            return SunTimes.Instance.CalculateSunRiseSetTimes(location, CurrentTime);           

        }

        public string Second
        {
            get
            {
                var seconds = CurrentTime.Second.ToString();
                if (seconds.Length == 1) seconds = "0" + seconds;
                return seconds;
            }
        }
    }
}