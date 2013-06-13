using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;

namespace Agent.Faces
{
    public class Device
    {
        public Device()
        {
            Time = new Time();
            Border = new Border();
        }
        
        
        public Location Location { get; set; }
        public Border Border { get; set; }

        public static int ScreenHeight
        {
            get { return SystemMetrics.ScreenHeight; }
        }

        public static int ScreenWidth
        {
            get { return SystemMetrics.ScreenWidth; }
        }

        public static int AgentSize
        {
            get { return 128; }
        }


        private object _lock = new object();
        private Bitmap _DrawingSurface;
        private Painter _painter;

        public Painter Painter
        {
            get { return _painter; }
        }

        public Time Time { get; set; }
        public Bitmap DrawingSurface
        {
            get
            {
                lock (_lock)
                {
                    if (_DrawingSurface == null)
                    {
                        _DrawingSurface = new Bitmap(ScreenWidth, ScreenHeight);
                        _painter = new Painter(_DrawingSurface);
                    }
                }
                return _DrawingSurface;
            }
        }

        private Font _SmallFont = Resources.GetFont(Resources.FontResources.small);

        public Font SmallFont
        {
            get { return _SmallFont; }
        }

        private Font _NinaBFont = Resources.GetFont(Resources.FontResources.NinaB);

        public Font NinaBFont
        {
            get { return _NinaBFont; }
        }

        public static Point Center
        {
            get { return new Point(64, 64); }
        }

        private Font _Candara48NPSSp = Resources.GetFont(Resources.FontResources.Candara48NPSSp);
        public Font DefaultFont
        {
            get { return _Candara48NPSSp; }
        }
        private Font _medium = Resources.GetFont(Resources.FontResources.BookAntiquaNumbers);

        public Font MediumFont
        {
            get { return _medium; }
        }

        private Font _Digital12 = Resources.GetFont(Resources.FontResources.Digital712point);

        public Font Digital12
        {
            get { return _Digital12; }
        }  
        private Font _Digital20 = Resources.GetFont(Resources.FontResources.Digital720point);

        public Font Digital20
        {
            get { return _Digital20; }
        }

        private Font _Buxton24 = Resources.GetFont(Resources.FontResources.Buxton24lcaseSpecial);

        public Font Buxton24
        {
            get { return _Buxton24; }
        }
        private Font _Buxton20 = Resources.GetFont(Resources.FontResources.Buxton20lcaseSpecial);

        public Font Buxton20
        {
            get { return _Buxton20; }
        }


    }
}