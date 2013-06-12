using System;
using Microsoft.SPOT;

namespace Agent.Faces
{
    public class Suntime
    {
        public Location Location { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public bool IsSunSet { get; set; }
        public bool IsSunRise { get; set; }
        public bool Valid { get; set; }
    }
}
