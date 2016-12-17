using System.Collections.Generic;

namespace TagsCloudApp
{
    class BoringWordsStorage
    {
        private readonly HashSet<string> boringWords = new HashSet<string>();

        public void LoadBoringWords(IEnumerable<string> words)
        {
            boringWords.Clear();
            boringWords.UnionWith(words);
        }

        public bool ContainsWord(string word)
        {
            return boringWords.Contains(word);
        }
    }
}
