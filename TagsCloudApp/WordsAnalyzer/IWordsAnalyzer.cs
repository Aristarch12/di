using System.Collections;
using System.Collections.Generic;

namespace TagsCloudApp.WordsAnalyzer
{
    interface IWordsAnalyzer
    {
        IEnumerable<WeightedWord> Сonsider(IEnumerable<string> words);
    }

    class WeightedWord
    {
        public int Weight { get; set; }
        public string Word { get; set; }

        public WeightedWord(string word, int weight)
        {
            Weight = weight;
            Word = word;
        }
    }
}
