using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TagsCloudApp.Settings;
using TagsCloudApp.WordsAnalyzer;

namespace TagsCloudApp.Layouters
{
    class TagLayouter : ITagLayouter
    {
        private readonly IRectangleLayouter rectangleLayouter;
        private readonly FontSettings fontSettings;


        public TagLayouter(IRectangleLayouter rectangleLayouter, FontSettings fontSettings)
        {
            this.rectangleLayouter = rectangleLayouter;
            this.fontSettings = fontSettings;
        }

        public IEnumerable<Tag> PutWords(IEnumerable<WeightedWord> weightedWords)
        {
            rectangleLayouter.Clear();
            if (!weightedWords.Any())
            {
                yield break;
            }
            weightedWords = weightedWords.OrderByDescending(w => w.Weight).ToArray();
            var maxWeight = weightedWords.Max(w => w.Weight);
            var minWeight = weightedWords.Min(w => w.Weight);
            foreach (var word in weightedWords)
            {
                yield return GetNextTag(word, minWeight, maxWeight);
            }
        }

        public void SetCenter(Point center)
        {
            rectangleLayouter.Center = center;
        }

        private Tag GetNextTag(WeightedWord weightedWord, int minWeight, int maxWeight)
        {
            var fontSize = GetFontSize(weightedWord.Weight, minWeight, maxWeight);
            var font = new Font(fontSettings.FontFamily, fontSize);
            var frameSize = TextRenderer.MeasureText(weightedWord.Word, font);
            var frame = rectangleLayouter.PutNextRectangle(frameSize);
            return new Tag(weightedWord.Word, frame, font);
        }

        private int GetFontSize(int currentWeight, int minWeight, int maxWeight)
        {
            var coef = (double)(currentWeight - minWeight)/(maxWeight - minWeight + 1);
            return (int)Math.Round(fontSettings.MinFontSize + coef*(fontSettings.MaxFontSize - fontSettings.MinFontSize));
        }

        
    }
}
