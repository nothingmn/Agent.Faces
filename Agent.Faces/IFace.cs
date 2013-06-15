using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Input;

namespace Agent.Faces
{
    public interface IFace
    {
        void RenderFace(Device device);
        void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time, Device device);
    }
}
