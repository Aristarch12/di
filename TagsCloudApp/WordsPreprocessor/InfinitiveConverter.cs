using System.Collections.Generic;
using System.Linq;
using NHunspell;
using TagsCloudApp.Settings;

namespace TagsCloudApp.WordsPreprocessor
{
    public class InfinitiveConverter : IWordsPreprocessor
    {
        private readonly InfinitiveConverterSettings settings;

        public InfinitiveConverter(InfinitiveConverterSettings settings)
        {
            this.settings = settings;
        }

        public IEnumerable<string> Prepare(IEnumerable<string> wordFlow)
        {
            using (var hunspell = new Hunspell(settings.AffFile, settings.DictFile))
            {
                return wordFlow.Select(word =>
                {
                    var stem = hunspell.Stem(word);
                    return stem.Any() ? stem.First() : word;
                }).ToList();
            }
        }
    }
}
