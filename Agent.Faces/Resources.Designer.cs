//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18047
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Agent.Faces
{
    
    internal partial class Resources
    {
        private static System.Resources.ResourceManager manager;
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if ((Resources.manager == null))
                {
                    Resources.manager = new System.Resources.ResourceManager("Agent.Faces.Resources", typeof(Resources).Assembly);
                }
                return Resources.manager;
            }
        }
        internal static Microsoft.SPOT.Font GetFont(Resources.FontResources id)
        {
            return ((Microsoft.SPOT.Font)(Microsoft.SPOT.ResourceUtility.GetObject(ResourceManager, id)));
        }
        internal static byte[] GetBytes(Resources.BinaryResources id)
        {
            return ((byte[])(Microsoft.SPOT.ResourceUtility.GetObject(ResourceManager, id)));
        }
        [System.SerializableAttribute()]
        internal enum FontResources : short
        {
            Digital720point = -31240,
            Candara48NPSSp = -12315,
            Buxton20lcaseSpecial = -11168,
            Digital712point = -5624,
            BookAntiquaNumbers = 10697,
            small = 13070,
            small1 = 14787,
            NinaB = 18060,
            Buxton24lcaseSpecial = 18181,
        }
        [System.SerializableAttribute()]
        internal enum BinaryResources : short
        {
            Mario_Time_1 = -12343,
        }
    }
}
