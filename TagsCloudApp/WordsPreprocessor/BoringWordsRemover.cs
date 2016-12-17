using System.Collections.Generic;
using System.Linq;

namespace TagsCloudApp.WordsPreprocessor
{
    class BoringWordsRemover : IWordsPreprocessor
    {
        private readonly BoringWordsStorage storage;

        public BoringWordsRemover(BoringWordsStorage storage)
        {
            this.storage = storage;
        }

        public IEnumerable<string> Prepare(IEnumerable<string> wordFlow)
        {
            return wordFlow.Where(w => !storage.ContainsWord(w));
        }
    }
}