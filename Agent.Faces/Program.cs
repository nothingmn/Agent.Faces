using System;
using Agent.Faces.Faces;

namespace Agent.Faces
{
    public class Program
    {
        public static void Main()
        {
            
            var watchFace = new WatchFace();
            //watchFace.Start(new MultiFace(), 5);
            //watchFace.Start(new AnimationFace(), 0);
            //watchFace.Start(new BigHands(), 1);
            //watchFace.Start(new AnimatedBigHands(), 0);
            watchFace.Start(new BigTextFace(), 0.05);
            
        }

    }
}
