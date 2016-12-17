using System.Drawing;

namespace TagsCloudApp.Settings
{
    public class ImageSettings
    {
        public int Width { get; set; } = 300;
        public int Height { get; set; } = 300;
        public Point Center => new Point(Width /2, Height / 2);
        public Color TextColor { get; set; }
        public Color BackdgoundColor { get; set; }
    }
}