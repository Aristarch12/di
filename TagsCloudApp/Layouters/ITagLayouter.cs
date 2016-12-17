using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TagsCloudApp.WordsAnalyzer;

namespace TagsCloudApp.Layouters
{
    interface ITagLayouter
    {
        IEnumerable<Tag> PutWords(IEnumerable<WeightedWord> weightedWords);
        void SetCenter(Point center);
    }
}
