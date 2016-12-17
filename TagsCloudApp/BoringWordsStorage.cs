using System.Collections.Generic;

namespace TagsCloudApp
{
    public class BoringWordsStorage
    {
        private readonly HashSet<string> boringWords = new HashSet<string>(new WordComparer());

        public void LoadBoringWords(IEnumerable<string> words)
        {
            boringWords.Clear();
            boringWords.UnionWith(words);
        }

        public bool Contains(string word)
        {
            return boringWords.Contains(word);
        }
    }

    class WordComparer : IEqualityComparer<string>
    {
        public bool Equals(string s1, string s2)
        {
            return s1.ToLower().Equals(s2.ToLower());
        }

        public int GetHashCode(string obj)
        {
            return base.GetHashCode();
        }
    }
}
