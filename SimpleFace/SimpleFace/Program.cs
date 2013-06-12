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
            var face = new WatchFace();
            face.OnSetupCompleted += watchFace_OnSetupCompleted;
            face.OnPaint += watchFace_OnPaint;
            face.OnComplete += face_OnComplete;
            face.Start(updateSpeed);

        }

        static void face_OnComplete(WatchFace face, Device device)
        {
            Debug.Print("Face print complete");
        }

        static void watchFace_OnPaint(WatchFace face, Device device)
        {
           
            device.DrawingSurface.DrawText(device.HourMinute, device.DefaultFont, Color.White, 5, 5);
            device.DrawingSurface.DrawLine(Color.White, 2, 0, 0, Device.ScreenWidth, Device.ScreenHeight);

            if(device.Border !=null) device.Border.Draw(device.DrawingSurface);
            
        }

        static void watchFace_OnSetupCompleted(WatchFace face, Device device)
        {
            device.Border = new Border() { Thickness = 1, FooterHeight = 5, HeaderHeight = 5 };     
        }



    }
}