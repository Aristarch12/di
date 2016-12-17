using System.Collections.Generic;

namespace TagsCloudApp.DataProcessors
{
    interface IDataProcessor
    {
        IEnumerable<string> SelectTagPhrases(string data);
        IEnumerable<string> SplitWords(string data);
    }
}
