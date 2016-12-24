using System;
using System.Collections.Generic;
using System.Linq;

namespace TagsCloudApp.DataProcessors
{
    class TextProcessor : IDataProcessor
    {
        public IEnumerable<string> SelectTagPhrases(string data)
        {
            return data.Split().Select(w => w.TrimEnd(',', '.', '!', '"', '?', ';', ':')).Where(p => p.Any());
        }

        public IEnumerable<string> SplitWords(string data)
        {
            return data.Split(',', ' ').Where(p => p.Any());
        }
    }
}
