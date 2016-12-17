using System.Collections.Generic;
using System.Linq;

namespace TagsCloudApp.WordsPreprocessor
{
    class LowerCaseConverter : IWordsPreprocessor
    {
        public IEnumerable<string> Prepare(IEnumerable<string> wordFlow)
        {
            return wordFlow.Select(word => word.ToLower());
        }
    }
}
