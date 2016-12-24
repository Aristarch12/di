using System.Collections.Generic;
using System.Linq;

namespace TagsCloudApp.WordsPreprocessor
{
    public class Preprocessor 
    {
        private readonly IWordsPreprocessor[] preprocessors;
        public Preprocessor(IWordsPreprocessor[] preprocessors)
        {
            this.preprocessors = preprocessors;
        }

        public Result<IEnumerable<string>> Prepare(IEnumerable<string> wordFlow)
        {
            var result = wordFlow.AsResult();
            foreach (var wordsPreprocessor in preprocessors)
            {
                result = result.Then(wordsPreprocessor.Prepare);
            }
            return result;

        }

    }
    
}