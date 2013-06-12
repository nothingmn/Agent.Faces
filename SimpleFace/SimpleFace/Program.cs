using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;

namespace SimpleFace
{
    public class Program : Microsoft.SPOT.Application
    {
        /// <summary>
        /// 1000 = 1 second
        /// </summary>
        private static int updateSpeed = 1000*5;

        public static void Main()
        {
            var face = new Face();
            face.OnSetupCompleted += face_OnSetupCompleted;
            face.OnPaint += face_OnPaint;
            face.Start(updateSpeed);

        }

        static void face_OnPaint(Face face, Device device)
        {
           
            device.DrawingSurface.DrawText(device.HourMinute, device.DefaultFont, Color.White, 5, 5);
            device.DrawingSurface.DrawLine(Color.Black, 2, 0, 0, Device.ScreenWidth, Device.ScreenHeight);

            if(device.Border !=null) device.Border.Draw(device.DrawingSurface);

            //remember to call complete, we are all done painting
            face.Complete();
        }

        static void face_OnSetupCompleted(Face face, Device device)
        {
            device.Border = new Border() { Thickness = 1, FooterHeight = 5, HeaderHeight = 5 };     
        }



    }
}