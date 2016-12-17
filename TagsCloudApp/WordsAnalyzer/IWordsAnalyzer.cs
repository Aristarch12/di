using System.Collections;
using System.Collections.Generic;

namespace TagsCloudApp.WordsAnalyzer
{
    public interface IWordsAnalyzer
    {
        IEnumerable<WeightedWord> Сonsider(IEnumerable<string> words);
    }
}
