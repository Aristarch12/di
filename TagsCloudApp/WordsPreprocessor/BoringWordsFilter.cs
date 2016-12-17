using System.Collections.Generic;
using System.Linq;

namespace TagsCloudApp.WordsPreprocessor
{
    public class BoringWordsFilter : IWordsPreprocessor
    {
        private readonly BoringWordsStorage storage;

        public BoringWordsFilter(BoringWordsStorage storage)
        {
            this.storage = storage;
        }

        public IEnumerable<string> Prepare(IEnumerable<string> wordFlow)
        {
            return wordFlow.Where(w => !storage.Contains(w));
        }
    }
}