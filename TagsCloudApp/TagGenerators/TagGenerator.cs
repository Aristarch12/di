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

        public Result<List<Tag>> GetTags(IEnumerable<string> keywords, Point center)
        {
            tagLayouter.SetCenter(center);
            return wordsPreprocessor.Prepare(keywords)
                .Then(wordsAnalyzer.Сonsider)
                .Then(tagLayouter.PutWords)
                .Then(e => e.ToList())
                .RefineError("An error occurred in getting the tags");

        }
    }
}