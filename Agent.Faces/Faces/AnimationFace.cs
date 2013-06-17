using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class AnimationFace : IFace
    {
        private int  min;
        private Font font;
        private Device _device;
        private Bitmap _bitmap;
        private int animationCycleSpeed = 25;
        private Timer timer, normalTimer;
        public void RenderFace(Device device)
        {
            if (_device == null) _device = device;
            if (font == null) font = _device.NinaBFont;
            min = 0;
            AnimateIt();
        }
        private void NormalSpeed()
        {
            normalTimer = new Timer(state =>
            {
                _device.Time.CurrentTime = DateTime.Now;
                //clear the display
                _device.DrawingSurface.Clear();

                _device.Painter.PaintHourHand(Color.White, 1, _device.Time.CurrentTime.Hour, _device.Time.CurrentTime.Minute);
                _device.Painter.PaintMinuteHand(Color.White, 1, _device.Time.CurrentTime.Minute, _device.Time.CurrentTime.Second);
                _device.Painter.PaintSecondHand(Color.White, 1, _device.Time.CurrentTime.Second);

                //flush the image out to the device
                _device.DrawingSurface.Flush();


            }, null, 1, 1000);
        }

        private void AnimateIt()
        {
            timer = new Timer(state =>
                {
                   
                    //clear the display
                    _device.DrawingSurface.Clear();

                    PaintIt();

                    //flush the image out to the device
                    _device.DrawingSurface.Flush();
                    min++;

                    if (min >= _device.Time.CurrentTime.Minute)
                    {
                        timer.Change(Timeout.Infinite, -1);
                        NormalSpeed();
                    }

                }, null, 1, animationCycleSpeed);
        }

        private void PaintIt()
        {
            
            //_device.DrawingSurface.DrawText(text, font, color, x, y);
            //_device.DrawingSurface.DrawImage(x,y,_bitmap,0, 0, _bitmap.Width, _bitmap.Height);
            _device.Painter.PaintHourHand(Color.White, 1, _device.Time.CurrentTime.Hour, _device.Time.CurrentTime.Minute);
            _device.Painter.PaintMinuteHand(Color.White, 1, min, _device.Time.CurrentTime.Second);
            _device.Painter.PaintSecondHand(Color.White, 1, _device.Time.CurrentTime.Second);
        }

        public void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time,
                                  Device device)
        {
        }
    }
}