using System.Collections.Generic;
using System.Drawing;
using TagsCloudApp.Layouters;
using TagsCloudApp.Settings;

namespace TagsCloudApp
{
    public class CloudPainter
    {
        private readonly Canvas canvas;
        private readonly ImageSettings settings;
        private readonly Brush brush;

        public CloudPainter(Canvas canvas, ImageSettings settings)
        {
            this.canvas = canvas;
            this.settings = settings;
            brush = new SolidBrush(settings.TextColor);
        }

        public void Paint(IEnumerable<Tag> tags)
        {
            canvas.RecreateImage(settings);
            using (var graphics = canvas.StartDrawing())
            {
                var background—olor = settings.BackdgoundColor;
                graphics.Clear(background—olor);
                foreach (var tag in tags)
                {
                    DrawPhrase(graphics, tag);
                }
            }
        }

        private void DrawPhrase(Graphics graphics, Tag tag)
        {
            graphics.DrawString(
                tag.Phrase,
                tag.Font,
                brush,
                tag.Rectangle.Location
                );
        }
    }
}