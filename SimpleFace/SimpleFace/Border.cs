using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Media;

namespace SimpleFace
{
    public class Border
    {
        public Border()
        {
            Thickness = 0;
        }
        public int Thickness { get; set; }
        public int HeaderHeight { get; set; }
        public int FooterHeight { get; set; }

        public void Draw(Bitmap DrawingSurface)
        {
            if (Thickness > 0)
            {
                //DrawingSurface.DrawRectangle(Color.White, Thickness, 0, 0, Device.ScreenWidth, Device.ScreenHeight, 0, 0,
               //                              Color.Black, 0, 0, Color.Black, 0, 0, 0);
            }
        }
    }
}
