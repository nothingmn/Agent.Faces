using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Media;

namespace SimpleFace
{
    public class WatchFace
    {
        public delegate void SetupCompleted(WatchFace face, Device device);
        public event SetupCompleted OnSetupCompleted;
        public delegate void Paint(WatchFace face, Device device);
        public event Paint OnPaint;

        public Device CurrentDevice { get; set; }

        public void Start(int PaintSpeed)
        {
            if (OnPaint == null)
                throw new NotSupportedException("The calling application must subscribe to the OnPaint event");

            // Included font is used in the clock
            CurrentDevice = new Device();
            if (OnSetupCompleted != null) OnSetupCompleted(this, CurrentDevice);
            var timer = new Timer(state =>
            {
                //clear the display
                CurrentDevice.DrawingSurface.Clear();

                //call the user code
                if (OnPaint != null) OnPaint(this, CurrentDevice);
                
                //flush the image out to the device
                CurrentDevice.DrawingSurface.Flush();


            }, null, 1, PaintSpeed);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
