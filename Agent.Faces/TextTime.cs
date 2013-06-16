using System;
using System.Collections;
using Microsoft.SPOT;

namespace Agent.Faces
{
    public class TextTime
    {
        public enum FontResourcesCopy
        {
            SegoeUI18Regular = -17753,
            SegoeUI18Bold = 11730,
            SegoeUI23Bold = -27413,
            SegoeUI14Bold = 15854,
            SegoeUI12Regular = 18149,
            SegoeUI14Regular = 2094,
            SegoeUI23Regular = 26621
        }
        private static ArrayList Numbers = new ArrayList();

        public int Digit { get; set; }
        public string Text { get; set; }
        public string Language { get; set; }
        public FontResourcesCopy FontHour { get; set; }
        public FontResourcesCopy FontMinute { get; set; }
        
        static TextTime()
        {
            #region TextNumbers

            Numbers.Add(new TextTime()
                {
                    Digit = 0,
                    Text = "zero",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular,
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 1,
                    Text = "one",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 2,
                    Text = "two",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 3,
                    Text = "three",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 4,
                    Text = "four",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 5,
                    Text = "five",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 6,
                    Text = "six",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 7,
                    Text = "seven",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 8,
                    Text = "eight",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 9,
                    Text = "nine",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 10,
                    Text = "ten",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 11,
                    Text = "eleven",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 12,
                    Text = "twelve",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 13,
                    Text = "thirteen",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 14,
                    Text = "fourteen",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 15,
                    Text = "fifteen",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 16,
                    Text = "sixteen",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 17,
                    Text = "seventeen",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 18,
                    Text = "eighteen",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 19,
                    Text = "nineteen",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 20,
                    Text = "twenty",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 21,
                    Text = "twenty one",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 22,
                    Text = "twenty two",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 23,
                    Text = "twenty three",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 24,
                    Text = "twenty four",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 25,
                    Text = "twenty five",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 26,
                    Text = "twenty six",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 27,
                    Text = "twenty seven",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 28,
                    Text = "twenty eight",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 29,
                    Text = "twenty nine",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 30,
                    Text = "thirty",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 31,
                    Text = "thirty one",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 32,
                    Text = "thirty two",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 33,
                    Text = "thirty three",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 34,
                    Text = "thirty four",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 35,
                    Text = "thirty five",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 36,
                    Text = "thirty six",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 37,
                    Text = "thirty seven",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 38,
                    Text = "thirty eight",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 39,
                    Text = "thirty nine",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 40,
                    Text = "fourty",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 41,
                    Text = "fourty one",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 42,
                    Text = "fourty two",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 43,
                    Text = "fourty three",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 44,
                    Text = "fourty four",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 45,
                    Text = "fourty five",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 46,
                    Text = "fourty six",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 47,
                    Text = "fourty seven",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 48,
                    Text = "fourty eight",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 49,
                    Text = "fourty nine",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 50,
                    Text = "fifty",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 51,
                    Text = "fifty one",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 52,
                    Text = "fifty two",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 53,
                    Text = "fifty three",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 54,
                    Text = "fifty four",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 55,
                    Text = "fifty five",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 56,
                    Text = "fifty six",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 57,
                    Text = "fifty seven",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI14Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 58,
                    Text = "fifty eight",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI14Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 59,
                    Text = "fifty nine",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 60,
                    Text = "oh",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI18Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 61,
                    Text = "midnight",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });
            Numbers.Add(new TextTime()
                {
                    Digit = 62,
                    Text = "noon",
                    Language = "en",
                    FontHour = FontResourcesCopy.SegoeUI23Bold,
                    FontMinute = FontResourcesCopy.SegoeUI18Regular
                });

            #endregion
        }


        public static TextTime TextHourFriendly(int hour)
        {

            if (hour == 0)
            {
                hour = 61;
            }
            else if (hour == 12)
            {
                hour = 62;
            }
            return (Numbers[hour] as TextTime);

        }
        
        public static TextTime TextHourLiteral(int hour)
        {
            if (hour > 12) hour = hour - 12;
            if (hour == 0) hour = 12;
            
            return (Numbers[hour] as TextTime);

        }

        public static TextTime TextMinute(int minute)
        {
            return (Numbers[minute] as TextTime);
        }

        public static TextTime TextTimeSeperator()
        {
            return (Numbers[60] as TextTime);
        }
    }
}