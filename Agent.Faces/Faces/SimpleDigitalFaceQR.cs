using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class SimpleDigitalFaceQR : IFace
    {
        private bool showingQR = false;
        private byte[] qrBytes = Resources.GetBytes(Resources.BinaryResources.RobChartiervCard);

        public void RenderFace(Device device)
        {
            device.Border = new Border() {Thickness = 1, FooterHeight = 0, HeaderHeight = 0};
            if (showingQR)
            {
                device.Painter.PaintCentered(qrBytes, Bitmap.BitmapImageType.Gif);
            }
            else
            {
                string time = (device.Time.HourMinute + " " + device.Time.AMPM).ToLower();
                device.Painter.PaintCentered(time, device.Digital20, Color.White);
            }
        }

        public void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time,
                                  Device device)
        {
            if (button == Buttons.Top && direction == ButtonDirection.Up)
            {
                showingQR = !showingQR;
                //clear the display
                device.DrawingSurface.Clear();

                //render our border, if necessary
                if (device.Border != null) device.Border.Draw(device.DrawingSurface);
                RenderFace(device);
                //flush the image out to the device
                device.DrawingSurface.Flush();
            }

        }
    }
}
