using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class BigHands : IFace
    {
        private Bitmap img = new Bitmap(Resources.GetBytes(Resources.BinaryResources.Face), Bitmap.BitmapImageType.Gif);

        public void RenderFace(Device device)
        {
            device.Border = new Border() {Thickness = 0, FooterHeight = 0, HeaderHeight = 0};
            device.DrawingSurface.DrawImage(0, 0, img, 0, 0, img.Width, img.Height);
            device.Painter.PaintThickHands(device);

        }


        public void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time,
                                  Device device)
        {
        }
    }
}