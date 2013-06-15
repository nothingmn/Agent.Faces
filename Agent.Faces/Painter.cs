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

        public void PaintImage(byte[] imageData, Bitmap.BitmapImageType imageType, Point point)
        {
            var img = new Bitmap(imageData, imageType);
            bitmap.DrawImage(point.X, point.Y, img, 0, 0, img.Height, img.Width);

        }

        public void PaintCentered(byte[] ImageData, Bitmap.BitmapImageType ImageType)
        {
            var img = new Bitmap(ImageData, ImageType);
            int x = (Device.AgentSize/2) - (img.Width/2);
            int y = (Device.AgentSize/2) - (img.Height/2);
            bitmap.DrawImage(x, y, img, 0, 0, img.Width, img.Height);

        }


        private const int TRANSLATE_RADIUS_SECONDS = 47;
        private const int TRANSLATE_RADIUS_MINUTES = 40;
        private const int TRANSLATE_RADIUS_HOURS = 30;

        public Point MinuteHandLocation(int minute, int second)
        {
            int min = (int) ((6*minute) + (0.1*second)); // Jump to Minute and add offset for 6 degrees over 60 seconds'
            return PointOnCircle(TRANSLATE_RADIUS_MINUTES, min + (-90), Device.Center);
        }

        public Point HourHandLocation(int hour, int minute)
        {
            int hr = (int) ((30*(hour%12)) + (0.5*minute));
                // Jump to Hour and add offset for 30 degrees over 60 minutes
            return PointOnCircle(TRANSLATE_RADIUS_HOURS, hr + (-90), Device.Center);
        }

        public Point SecondHandLocation(int second)
        {
            int sec = 6*second;
            return PointOnCircle(TRANSLATE_RADIUS_SECONDS, sec + (-90), Device.Center);
        }

        public void PaintMinuteHand(Color color, int thickness, int minute, int second)
        {
            PaintLine(color, thickness, Device.Center, MinuteHandLocation(minute, second));
        }

        public void PaintSecondHand(Color color, int thickness, int second)
        {

            PaintLine(color, thickness, Device.Center, SecondHandLocation(second));
        }

        public void PaintHourHand(Color color, int thickness, int hour, int minute)
        {
            PaintLine(color, thickness, Device.Center, HourHandLocation(hour, minute));

        }

        public void PaintLine(Color color, int thickness, Point start, Point end)
        {
            bitmap.DrawLine(color, thickness, start.X, start.Y, end.X, end.Y);
        }


        private Point PointOnCircle(float radius, float angleInDegrees, Point origin)
        {
            return new Point(
                (int) (radius*System.Math.Cos(angleInDegrees*System.Math.PI/180F)) + origin.X,
                (int) (radius*System.Math.Sin(angleInDegrees*System.Math.PI/180F)) + origin.Y
                );
        }


        public void PaintThickHands(Device device)
        {
            Point textLocation = new Point(
           Device.Center.X - (device.Painter.MeasureString("agent", device.SmallFont) / 2), Device.Center.Y - 30);
            device.DrawingSurface.DrawText("agent", device.SmallFont, Color.White, textLocation.X, textLocation.Y);


            Point hourTop = device.Painter.HourHandLocation(device.Time.CurrentTime.Hour, device.Time.CurrentTime.Minute);
            Point minuteTop = device.Painter.MinuteHandLocation(device.Time.CurrentTime.Minute,
                                                                device.Time.CurrentTime.Second);
            Point secondTop = device.Painter.SecondHandLocation(device.Time.CurrentTime.Second);
            PaintBigHand(hourTop, Device.Center, device);
            PaintBigHand(minuteTop, Device.Center, device);
            PaintBigHand(secondTop, Device.Center, device);

            //fill
            PaintBigHand(hourTop, Device.Center, device, 1);
            PaintBigHand(hourTop, Device.Center, device, 0);

            PaintBigHand(minuteTop, Device.Center, device, 1);
            PaintBigHand(minuteTop, Device.Center, device, 0);

            PaintBigHand(secondTop, Device.Center, device, 1);
            PaintBigHand(secondTop, Device.Center, device, 0);

            device.DrawingSurface.DrawEllipse(Color.White, 1, Device.Center.X, Device.Center.Y, 3, 3, Color.White, 0, 0,
                                              Color.White, 0, 0, 255);
        }

        private void PaintBigHand(Point top, Point bottom, Device device, int width = 2)
        {

            //2 pixels wide for white hand

            Point hourBottomLeft = new Point(top.X - width, top.Y + width);
            Point hourTopLeft = new Point(top.X + width, top.Y - width);
            device.DrawingSurface.DrawLine(Color.White, 1, hourBottomLeft.X, hourBottomLeft.Y, hourTopLeft.X,
                                           hourTopLeft.Y);

            Point hourBottomRight = new Point(bottom.X - width, bottom.Y + width);
            Point hourTopRight = new Point(bottom.X + width, bottom.Y - width);
            device.DrawingSurface.DrawLine(Color.White, 1, hourBottomRight.X, hourBottomRight.Y, hourTopRight.X,
                                      hourTopRight.Y);

            device.DrawingSurface.DrawLine(Color.White, 1, hourBottomLeft.X, hourBottomLeft.Y, hourBottomRight.X, hourBottomRight.Y);
            device.DrawingSurface.DrawLine(Color.White, 1, hourTopLeft.X, hourTopLeft.Y, hourTopRight.X, hourTopRight.Y);

        }
    }
}