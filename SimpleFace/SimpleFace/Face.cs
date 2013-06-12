using System;
using System.Threading;
using Microsoft.SPOT;

namespace SimpleFace
{
    public class Face
    {
        public delegate void SetupCompleted(Face face, Device device);
        public event SetupCompleted OnSetupCompleted;
        public delegate void Paint(Face face, Device device);
        public event Paint OnPaint;

        public Device Device { get; set; }
        public void Complete()
        {
            //flush the image out to the device
            Device.DrawingSurface.Flush();

        }
        public void Start(int PaintSpeed)
        {
            if (OnPaint == null)
                throw new NotSupportedException("The calling application must listen to the OnPaint event");

            // Included font is used in the clock
            Device = new Device();
            if (OnSetupCompleted != null) OnSetupCompleted(this, Device);
            var timer = new Timer(state =>
            {
                //clear the display
                Device.DrawingSurface.Clear();

                //call the user code
                if (OnPaint != null) OnPaint(this, Device);
                
            }, null, 0, PaintSpeed);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
