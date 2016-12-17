using System.Collections.Generic;
using System.Linq;
using NHunspell;

namespace TagsCloudApp.WordsPreprocessor
{
    public class InfinitiveConverter : IWordsPreprocessor
    {
        public IEnumerable<string> Prepare(IEnumerable<string> wordFlow)
        {
            var result = new List<string>();
            using (var hunspell = new Hunspell("ru_RU.aff", "ru_RU.dic"))
            {
                foreach (var word in wordFlow)
                {
                    var stem = hunspell.Stem(word);
                    result.Add(stem.Any() ? stem.First() : word);
                }
            }
            return result;
        }
    }
}
