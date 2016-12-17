using System.Collections.Generic;

namespace TagsCloudApp.WordsPreprocessor
{
    interface IWordsPreprocessor
    {
        IEnumerable<string> Prepare(IEnumerable<string> wordFlow);
    }
}
