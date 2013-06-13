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
            
            var watchFace = new WatchFace();
            watchFace.Start(new Illusion(), 30);
        }

    }
}
