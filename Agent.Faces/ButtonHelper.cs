using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation;


namespace Agent.Faces
{
    public class ButtonHelper
    {
        public delegate void ButtonPress(object sender, RoutedEventArgs args, Device device);
        public event ButtonPress OnButtonPress;
        public GPIOButtonInputProvider GpioButtonInputProvider { get; set; }
        private DateTime lastEvent = DateTime.Now;
        public int ButtonThreshold { get; set; }
 
        public ButtonHelper(Program program)
        {
            ButtonThreshold = 500;
            if (program.MainWindow == null) program.MainWindow = new Window();
            GpioButtonInputProvider = new GPIOButtonInputProvider(null);
            program.MainWindow.AddHandler(Buttons.ButtonUpEvent, new RoutedEventHandler(OnButtonUp), false);
            program.MainWindow.Visibility = Visibility.Visible;
            
            Buttons.Focus(program.MainWindow);
        }
        private void OnButtonUp(object sender, RoutedEventArgs routedEventArgs)
        {
            //TimeSpan ts = new TimeSpan(DateTime.Now.Ticks - lastEvent.Ticks);
            //if (ts.Milliseconds > ButtonThreshold)
            //{
                if (OnButtonPress != null) OnButtonPress(sender, routedEventArgs, null);
                lastEvent = DateTime.Now;
            //}
        }
    }
}
