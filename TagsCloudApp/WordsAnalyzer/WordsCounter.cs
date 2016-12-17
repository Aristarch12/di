using System.Collections.Generic;
using System.Linq;

namespace TagsCloudApp.WordsAnalyzer
{
    public class WordsCounter : IWordsAnalyzer
    {
        public IEnumerable<WeightedWord> Сonsider(IEnumerable<string> words)
        {
            return words.GroupBy(w => w).Select(g => new WeightedWord(g.Key, g.Count()));
        }
    }
}