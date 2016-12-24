using System;
using System.Drawing;

namespace TagsCloudApp.Settings
{
    public class ImageSettings
    {
        private int width = 300;
        private int height = 300;

        public int Width
        {
            get { return width; }
            set
            {
                if (value > 0)
                    width = value;
                else
                    throw new ArgumentException("Width must be a positive integer");
            }
        }

        public int Height
        {
            get { return height; }
            set
            {
                if (value > 0)
                    height = value;
                else
                    throw new ArgumentException("Height must be a positive integer");
            }
        }

        public Point Center => new Point(Width /2, Height / 2);
        public Color TextColor { get; set; }
        public Color BackdgoundColor { get; set; }
    }
}