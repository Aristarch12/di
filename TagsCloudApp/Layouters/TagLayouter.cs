using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TagsCloudApp.Settings;
using TagsCloudApp.WordsAnalyzer;

namespace TagsCloudApp.Layouters
{
    public class TagLayouter : ITagLayouter
    {
        private readonly IRectangleLayouter rectangleLayouter;
        private readonly FontSettings fontSettings;
        private Point center;
        private Rectangle Space => new Rectangle(0, 0, center.X * 2, center.Y * 2);

        public TagLayouter(IRectangleLayouter rectangleLayouter, FontSettings fontSettings)
        {
            this.rectangleLayouter = rectangleLayouter;
            this.fontSettings = fontSettings;
        }

        public Result<IEnumerable<Tag>> PutWords(IEnumerable<WeightedWord> weightedWords)
        {
            rectangleLayouter.Clear();
            if (!weightedWords.Any())
            {
                return Result.Ok(Enumerable.Empty<Tag>());
            }
            weightedWords = weightedWords.OrderByDescending(w => w.Weight).ToArray();
            var maxWeight = weightedWords.Max(w => w.Weight);
            var minWeight = weightedWords.Min(w => w.Weight);
            return Result.Of(() => weightedWords.Select(w => GetNextTag(w, minWeight, maxWeight)));
        }

        public void SetCenter(Point newCenter)
        {
            center = newCenter;
            rectangleLayouter.Center = newCenter;
        }

        private Tag GetNextTag(WeightedWord weightedWord, int minWeight, int maxWeight)
        {
            var fontSize = GetFontSize(weightedWord.Weight, minWeight, maxWeight);
            var font = new Font(fontSettings.FontFamily, fontSize);
            var frameSize = TextRenderer.MeasureText(weightedWord.Word, font);
            var rectangle = rectangleLayouter.PutNextRectangle(frameSize);
            if (Space.Contains(rectangle))
            {
                return new Tag(weightedWord.Word, rectangle, font);
            }
            throw new Exception("Tags do not fit in the space");
        }

        private int GetFontSize(int currentWeight, int minWeight, int maxWeight)
        {
            var coef = (double) (currentWeight - minWeight)/(maxWeight - minWeight + 1);
            return
                (int) Math.Round(fontSettings.MinFontSize + coef*(fontSettings.MaxFontSize - fontSettings.MinFontSize));
        }
    }
}