using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudApp.DataProcessors;
using TagsCloudApp.FileReaders;
using TagsCloudApp.Layouters;
using TagsCloudApp.WordsAnalyzer;
using TagsCloudApp.WordsPreprocessor;

namespace TagsCloudApp.TagGenerators
{
    class TagGenerator : ITagGenerator
    {
        private readonly IDataProcessor dataProcessor;
        private readonly Preprocessor wordsPreprocessor;
        private readonly IWordsAnalyzer wordsAnalyzer;
        private readonly ITagLayouter tagLayouter;
        private readonly IFileReader fileReader;

        public TagGenerator(
            IDataProcessor dataProcessor,
            Preprocessor wordsPreprocessor,
            IWordsAnalyzer wordsAnalyzer,
            ITagLayouter tagLayouter,
            IFileReader fileReader)
        {
            this.dataProcessor = dataProcessor;
            this.wordsPreprocessor = wordsPreprocessor;
            this.wordsAnalyzer = wordsAnalyzer;
            this.tagLayouter = tagLayouter;
            this.fileReader = fileReader;
        }

        public List<Tag> GetTags(IEnumerable<string> keywords, Point center)
        {
            var rightPhrases = wordsPreprocessor.Prepare(keywords);
            var weightedWords = wordsAnalyzer.Сonsider(rightPhrases);
            tagLayouter.SetCenter(center);
            return tagLayouter.PutWords(weightedWords).ToList();
        }
    }
}