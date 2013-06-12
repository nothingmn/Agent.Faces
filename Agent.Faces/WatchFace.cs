using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces
{
    public class WatchFace
    {

        public Device Device { get; set; }

        public void Start(IFace Face, int PaintSpeed = 60)
        {
            if (Face == null) throw new ArgumentNullException("Face cannot be null");
            // Included font is used in the clock
            Device = new Device();
            Device.Location = new Location() {Latitude = -122.2444, Longitude = 49.3};
            var timer = new Timer(state =>
                {
                    //update our local time reference
                    Device.Time.CurrentTime = DateTime.Now;

                    //clear the display
                    Device.DrawingSurface.Clear();

                    //render our border, if necessary
                    if (Device.Border != null) Device.Border.Draw(Device.DrawingSurface);

                    //call the user code
                    Face.RenderFace(Device);


                    //flush the image out to the device
                    Device.DrawingSurface.Flush();


                }, null, 1, PaintSpeed);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}