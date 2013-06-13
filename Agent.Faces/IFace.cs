using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Input;

namespace Agent.Faces
{
    public interface IFace
    {
        void RenderFace(Device device);
        void OnButtonPress(object sender, ButtonEventArgs args,Button button, Device device);
    }
}
