using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class BinaryFace : IFace      
    {
        public void RenderFace(Device device)
        {
            device.Border = new Border() { Thickness = 1, FooterHeight = 0, HeaderHeight = 0 };
            var h_eight = " - ";
            var h_four = " - ";
            var h_two = " - ";
            var h_one = " - ";
            int hour = Convert.ToInt32(device.Time.Hour);

            if (hour >= 8)
            {
                h_eight = " 8 ";
                hour -= 8;
            }
            Debug.Print(hour.ToString());
            if (hour >= 4)
            {
                h_four = " 4 ";
                hour -= 4;
            }
            Debug.Print(hour.ToString());
            if (hour >= 2)
            {
                h_two = " 2 ";
                hour -= 2;
            }
            Debug.Print(hour.ToString());
            if (hour >= 1)
            {
                h_one = " 1 ";
                hour -= 1;
            }
            Debug.Print(hour.ToString());
            var assembled = (h_eight + h_four + h_two + h_one).Trim();
            Debug.Print(assembled);

            var m_thirtytwo = " - ";
            var m_sixteen = " - ";
            var m_eight = " - ";
            var m_four = " - ";
            var m_two = " - ";
            var m_one = " - ";
            int min = DateTime.Now.Minute;
            if (min >= 32)
            {
                m_thirtytwo = " 32 ";
                min -= 32;
            }
            if (min >= 16)
            {
                m_sixteen = " 16 ";
                min -= 16;
            }
            if (min >= 8)
            {
                m_eight = " 8 ";
                min -= 8;
            }
            if (min >= 4)
            {
                m_four = " 4 ";
                min -= 4;
            }
            if (min >= 2)
            {
                m_two = " 2 ";
                min -= 2;
            }
            if (min >= 1)
            {
                m_one = " 1 ";
                min -= 1;
            }
            var minutes = (m_thirtytwo + m_sixteen + m_eight + m_four + m_two + m_one).Trim();
            int top = (Device.AgentSize / 2) - device.NinaBFont.Height * 3;

            device.DrawingSurface.DrawText("Hour:", device.NinaBFont, Color.White, 2, top);
            top = top + device.NinaBFont.Height + 1;

            device.Painter.PaintCentered(assembled, device.NinaBFont, Color.White, top);

            top = top + device.NinaBFont.Height * 2 + 1;
            device.DrawingSurface.DrawText("Minute:", device.NinaBFont, Color.White, 2, top);

            top = top + device.NinaBFont.Height + 1;
            device.Painter.PaintCentered(minutes, device.NinaBFont, Color.White, top);
        }

    }
}
