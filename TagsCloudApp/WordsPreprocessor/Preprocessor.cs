using System.Collections.Generic;
using System.Linq;

namespace TagsCloudApp.WordsPreprocessor
{
    class Preprocessor 
    {
        private readonly IWordsPreprocessor[] preprocessors;
        public Preprocessor(IWordsPreprocessor[] preprocessors)
        {
            this.preprocessors = preprocessors;
        }

        public IEnumerable<string> Prepare(IEnumerable<string> wordFlow)
        {
            return preprocessors.Aggregate(wordFlow, (current, wordsPreprocessor) => wordsPreprocessor.Prepare(current));
        }
    }
}