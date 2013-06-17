using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class AnimatedBigHands : IFace
    {

        private int sec = 0;
        private Font font;
        private Device _device;
        private Bitmap _bitmap;
        private int animationCycleSpeed = 25;
        private Timer timer, normalTimer;
        private bool animating = false;
        private Bitmap img = new Bitmap(Resources.GetBytes(Resources.BinaryResources.WatchFaceFromScratch),
                                        Bitmap.BitmapImageType.Gif);
        public void RenderFace(Device device)
        {
            if (_device == null) _device = device;
            if (font == null) font = _device.NinaBFont;
            sec = 0;
            AnimateIt();
        }
        private void NormalSpeed()
        {
            animating = false;
            normalTimer = new Timer(state =>
            {
                _device.Time.CurrentTime = DateTime.Now;
                //clear the display
                _device.DrawingSurface.Clear();
                _device.DrawingSurface.DrawImage(0, 0, img, 0, 0, img.Width, img.Height);

                var text = "agent";
                Point textLocation = new Point(
                    Device.Center.X - (_device.Painter.MeasureString(text, _device.SmallFont) / 2), Device.Center.Y - 25);
                _device.DrawingSurface.DrawText(text, _device.SmallFont, Color.White, textLocation.X, textLocation.Y);

                var date = _device.Time.MonthNameShort + " " + _device.Time.Day;
                Point dateLocation = new Point(
                    Device.Center.X - (_device.Painter.MeasureString(date, _device.SmallFont) / 2), Device.Center.Y + 20);
                _device.DrawingSurface.DrawText(date, _device.SmallFont, Color.White, dateLocation.X, dateLocation.Y);



                //device.Painter.PaintThickHands(device, true, true, false);
                _device.Painter.PaintSkinnyHands(_device);



                //device.Border = new Border() { Thickness = 1, FooterHeight = 0, HeaderHeight = 0 };
                //flush the image out to the device
                _device.DrawingSurface.Flush();


            }, null, 1, 1000);
        }

        private void AnimateIt()
        {
            animating = true;
            timer = new Timer(state =>
                {
                   
                    //clear the display
                    _device.DrawingSurface.Clear();

                    PaintIt();

                    //flush the image out to the device
                    _device.DrawingSurface.Flush();
            
                    sec++;
                    //var diff = _device.Time.CurrentTime.Second - sec;

                    //if (diff <= 5)
                    //{
                    //    animationCycleSpeed = animationCycleSpeed + diff;
                    //    timer.Change(animationCycleSpeed, animationCycleSpeed);
                    //}
                    
                    if (sec >= _device.Time.CurrentTime.Second)
                    {
                        timer.Change(Timeout.Infinite, -1);
                        NormalSpeed();
                    }
                }, null, 1, animationCycleSpeed);
        }

        private void PaintIt()
        {

            _device.DrawingSurface.DrawImage(0, 0, img, 0, 0, img.Width, img.Height);

            var text = "agent";
            Point textLocation = new Point(
                Device.Center.X - (_device.Painter.MeasureString(text, _device.SmallFont) / 2), Device.Center.Y - 25);
            _device.DrawingSurface.DrawText(text, _device.SmallFont, Color.White, textLocation.X, textLocation.Y);

            var date = _device.Time.MonthNameShort + " " + _device.Time.Day;
            Point dateLocation = new Point(
                Device.Center.X - (_device.Painter.MeasureString(date, _device.SmallFont) / 2), Device.Center.Y + 20);
            
            _device.DrawingSurface.DrawText(date, _device.SmallFont, Color.White, dateLocation.X, dateLocation.Y);


            _device.Painter.PaintHourHand(Color.White, 3, _device.Time.CurrentTime.Hour, _device.Time.CurrentTime.Minute);
            _device.Painter.PaintMinuteHand(Color.White, 2, _device.Time.CurrentTime.Minute,
                                           _device.Time.CurrentTime.Second);

            _device.Painter.PaintSecondHand(Color.White, 1, sec);

            _device.DrawingSurface.DrawEllipse(Color.White, 1, Device.Center.X, Device.Center.Y, 3, 3, Color.White, 0, 0,
                                  Color.White, 0, 0, 255);
            _device.DrawingSurface.DrawEllipse(Color.White, 1, Device.Center.X, Device.Center.Y, 2, 2, Color.Black, 0, 0,
                                              Color.White, 0, 0, 255);


            //device.Border = new Border() { Thickness = 1, FooterHeight = 0, HeaderHeight = 0 };
        }



        public void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time,
                                  Device device)
        {
            if (button == Buttons.Top && direction == ButtonDirection.Up && !animating)
            {
                normalTimer.Change(Timeout.Infinite, -1);
                sec = 0;
                animationCycleSpeed = 100;
                AnimateIt();
            }
            if (button == Buttons.Bottom && direction == ButtonDirection.Up && !animating)
            {
                normalTimer.Change(Timeout.Infinite, -1);
                sec = 0;
                animationCycleSpeed = 10;
                AnimateIt();
            }
            if (button == Buttons.Middle && direction == ButtonDirection.Up && !animating)
            {
                normalTimer.Change(Timeout.Infinite, -1);
                sec = 0;
                animationCycleSpeed = 50;
                AnimateIt();
            }
        }
    }
}