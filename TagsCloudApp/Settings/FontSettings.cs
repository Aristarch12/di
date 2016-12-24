using System;
using System.Drawing;

namespace TagsCloudApp.Settings
{
    public class FontSettings
    {
        private int minFontSize;
        private int maxFontSize;

        public FontSettings(FontFamily fontFamily, int minFontSize, int maxFontSize)
        {
            FontFamily = fontFamily;
            this.minFontSize = minFontSize;
            this.maxFontSize = maxFontSize;
        }
        public FontFamily FontFamily { get; set; }

        public int MinFontSize
        {
            get { return minFontSize; }
            set
            {
                if (value > 0)
                    minFontSize = value;
                else
                    throw new ArgumentException($"Incorrect field value {value}");
            }
        }

        public int MaxFontSize
        {
            get { return maxFontSize; }
            set
            {
                if (value > 0)
                    maxFontSize = value;
                else
                    throw new ArgumentException($"Incorrect field value {value}");
            }
        }
    }
}
