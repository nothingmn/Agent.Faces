using System;
using Agent.Faces.Faces;
using Microsoft.SPOT;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;

namespace Agent.Faces
{
    public class Program : Microsoft.SPOT.Application
    {
        public static void Main()
        {
            var WatchFace = new WatchFace();
            WatchFace.Start(new Lunar(), 1);
        }

    }
}
