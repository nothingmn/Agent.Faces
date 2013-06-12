using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces
{
    public class Painter
    {
        private Bitmap bitmap;

        public Painter(Bitmap Canvas)
        {
            bitmap = Canvas;
        }

        public int MeasureString(string text, Font font)
        {
            if (text == null || text.Trim() == "") return 0;
            int size = 0;
            for (int i = 0; i < text.Length; i++)
            {
                size += font.CharWidth(text[i]);
            }
            return size;
        }

        public void PaintBottomCenter(string text, Font font, Color color)
        {
            int x, y = 0;
            FindCenter(text, font, out x, out y);
            bitmap.DrawText(text, font, color, x, Device.AgentSize - font.Height);
        }

        public void PaintCentered(string text, Font Font, Color Color, int y)
        {
            int x, y1 = 0;
            FindCenter(text, Font, out x, out y1);

            bitmap.DrawText(text, Font, Color, x, y);
        }

        public void PaintCentered(string text, Font Font, Color Color)
        {

            int x, y = 0;
            FindCenter(text, Font, out x, out y);

            bitmap.DrawText(text, Font, Color, x, y);
        }

        public void FindCenter(string text, Font Font, out int x, out int y)
        {

            int size = MeasureString(text, Font);
            int center = Device.AgentSize/2;
            int centerText = size/2 - 2;
            x = center - centerText;

            y = center - (Font.Height/2);


        }
        public void PaintCentered(byte[] ImageData, Bitmap.BitmapImageType ImageType)
        {
            var img = new Bitmap(ImageData, ImageType);
            int x = (Device.AgentSize / 2) - (img.Width / 2);
            int y = (Device.AgentSize / 2) - (img.Height / 2);
            bitmap.DrawImage(x, y, img, 0, 0, img.Width, img.Height);
            
        }


        const int TRANSLATE_RADIUS_SECONDS = 47;
        const int TRANSLATE_RADIUS_MINUTES = 40;
        const int TRANSLATE_RADIUS_HOURS = 30;

        public void DrawMinuteHand(Color color, int thickness, int minute, int second)
        {
            int min = (int)((6 * minute) + (0.1 * second));      // Jump to Minute and add offset for 6 degrees over 60 seconds'
            Point p = PointOnCircle(TRANSLATE_RADIUS_MINUTES, min + (-90), Device.Center);
            DrawLine(color, thickness, Device.Center, p);
        }
        public void DrawSecondHand(Color color, int thickness, int second)
        {
            int sec = 6 * second;
            Point p = PointOnCircle(TRANSLATE_RADIUS_SECONDS, sec + (-90), Device.Center);
            DrawLine(color, thickness, Device.Center, p);
        }

        public void DrawHourHand(Color color, int thickness, int hour, int minute)
        {
            int hr = (int)((30 * (hour % 12)) + (0.5 * minute)); // Jump to Hour and add offset for 30 degrees over 60 minutes
            Point p = PointOnCircle(TRANSLATE_RADIUS_HOURS, hr + (-90), Device.Center);
            DrawLine(color, thickness, Device.Center, p);

        }

        public void DrawLine(Color color, int thickness, Point start, Point end)
        {
            bitmap.DrawLine(color, thickness, start.X, start.Y, end.X, end.Y);
        }


        private Point PointOnCircle(float radius, float angleInDegrees, Point origin)
        {
            return new Point(
                (int)(radius * System.Math.Cos(angleInDegrees * System.Math.PI / 180F)) + origin.X,
                (int)(radius * System.Math.Sin(angleInDegrees * System.Math.PI / 180F)) + origin.Y
            );
        }

    }
}