using System.Drawing;

namespace TagsCloudApp.Settings
{
    public class FontSettings
    {
        public FontSettings(FontFamily fontFamily, int minFontSize, int maxFontSize)
        {
            FontFamily = fontFamily;
            MinFontSize = minFontSize;
            MaxFontSize = maxFontSize;
        }
        public FontFamily FontFamily { get; set; }
        public int MinFontSize { get; set; }
        public int MaxFontSize { get; set; }

    }
}
