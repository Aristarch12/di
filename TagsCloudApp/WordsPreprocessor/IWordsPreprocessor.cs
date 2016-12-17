using System.Collections.Generic;

namespace TagsCloudApp.WordsPreprocessor
{
    public interface IWordsPreprocessor
    {
        IEnumerable<string> Prepare(IEnumerable<string> wordFlow);
    }
}
