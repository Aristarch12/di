using System.Collections.Generic;
using System.Linq;

namespace TagsCloudApp
{
    public class KeywordsStorage
    {
        private List<string> keywords = new List<string>();

        public void LoadKeywords(IEnumerable<string> newKeywords)
        {
            keywords = newKeywords.ToList();
        }

        public IEnumerable<string> GetKeywords()
        {
            return keywords;
        }
    }
}
