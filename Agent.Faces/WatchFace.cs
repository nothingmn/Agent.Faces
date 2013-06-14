using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Input;

namespace Agent.Faces
{
    public class WatchFace
    {
        public event ButtonHelper.ButtonPress OnButtonPress;
        public Device Device { get; set; }
        public IFace Face { get; set; }
        private ButtonHelper buttonHelper;
        private Program program;

        public WatchFace()
        {
            Device = new Device();
            Device.Location = new Location() { Latitude = -122.2444, Longitude = 49.3 };

            program = new Program();
            buttonHelper = new ButtonHelper(program);
            buttonHelper.OnButtonPress += buttonHelper_OnButtonPress;

        }
        public void Start(IFace face, double paintSpeedInSeconds = 60)
        {
            if (face == null) throw new ArgumentNullException("Face cannot be null");
            Face = face;
            // Included font is used in the clock
            
            var timer = new Timer(state =>
                {
                    Debug.Print("Tick");

                    //update our local time reference
                    Device.Time.CurrentTime = DateTime.Now; //just normal
                    //Device.Time.CurrentTime = Device.Time.CurrentTime.AddMinutes(1); //speedy time
                    //Device.Time.CurrentTime = new DateTime(2011, 12, 16, 12, 4, 0, 0); //hard coded time

                    //clear the display
                    Device.DrawingSurface.Clear();

                    //render our border, if necessary
                    if (Device.Border != null) Device.Border.Draw(Device.DrawingSurface);

                    //call the user code
                    face.RenderFace(Device);


                    //flush the image out to the device
                    Device.DrawingSurface.Flush();


                }, null, 1, (int)(paintSpeedInSeconds*1000f));
            Debug.Print("Going to sleep");
            program.Run(program.MainWindow);
            //Thread.Sleep(Timeout.Infinite);
        }

        private void buttonHelper_OnButtonPress(object sender, RoutedEventArgs args, Device device)
        {
            if (OnButtonPress != null) OnButtonPress(sender, args, Device);
            var bea = args as ButtonEventArgs;
            Face.OnButtonPress(sender, bea, bea.Button, Device);
        }
    }
}