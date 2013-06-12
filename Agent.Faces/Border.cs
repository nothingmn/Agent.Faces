using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces
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
                DrawingSurface.DrawRectangle(Color.White, Thickness, 1, 1, Device.AgentSize, Device.AgentSize, 0, 0,
                                             Color.Black, 0, 0, Color.Black, 0, 0, 0);

                if (HeaderHeight > 0)
                {
                    DrawingSurface.DrawLine(Color.White, Thickness, 1, HeaderHeight, Device.AgentSize, HeaderHeight);

                }
                if (FooterHeight > 0)
                {
                    DrawingSurface.DrawLine(Color.White, Thickness, 1, Device.AgentSize - FooterHeight, Device.AgentSize, Device.AgentSize - FooterHeight);

                }
            }
        }
    }
}
