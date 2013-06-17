using System;
using System.Collections;
using System.Reflection;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Microsoft.SPOT.Presentation.Media;

namespace Agent.Faces.Faces
{
    public class MultiFace : IFace
    {
        private bool IsInterfaceType(Type sourceType, Type interfaceType)
        {
            var interfaces = sourceType.GetInterfaces();
            foreach (var i in interfaces)
            {
                if (i == interfaceType) return true;
            }
            return false;
        }

        public MultiFace()
        {
            Type[] types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
            Type faceType = typeof (IFace);
            foreach (var t in types)
            {
                try
                {
                    if (IsInterfaceType(t, faceType))
                    {
                        faces.Add(t);
                    }
                }
                catch (Exception e)
                {
                }
            }
        }

        private int faceIndex = 0;
        private ArrayList faces = new ArrayList();
        private IFace currentFace;

        public void RenderFace(Device device)
        {

            RepaintFace(device);

        }

        private void RepaintFace(Device device)
        {
            if (currentFace == null)
            {
                var t = (faces[faceIndex] as Type);
                try
                {
                    var ctor = t.GetConstructor(new Type[0]);
                    if (ctor != null)
                    {
                        IFace instance = (ctor.Invoke(new object[0]) as IFace);
                        if (instance != null)
                        {
                            currentFace = instance;
                        }
                    }
                }
                catch (Exception)
                {
                }
                
            }
            if (currentFace != null) currentFace.RenderFace(device);
        }

        public
            void OnButtonPress(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time,
                               Device device)
        {
            if (button == Buttons.Top) faceIndex--;
            if (button == Buttons.Bottom) faceIndex++;
            if (faceIndex < 0) faceIndex = 0;
            if (faceIndex >= faces.Count) faceIndex = faces.Count-1;
            Debug.Print(faceIndex.ToString() + ":" + (faces[faceIndex] as Type).FullName);
            currentFace = null;
            RepaintFace(device);


        }

    }
}