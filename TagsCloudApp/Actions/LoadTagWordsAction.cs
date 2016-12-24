using System;
using System.Windows.Forms;
using TagsCloudApp.DataProcessors;
using TagsCloudApp.FileReaders;
using TagsCloudApp.Reporter;


namespace TagsCloudApp.Actions
{
    class LoadTagWordsAction : IUiAction
    {
        private readonly IFileReader fileReader;
        private readonly IDataProcessor dataProcessor;
        private readonly KeywordsStorage keywordsStorage;
        private readonly IReporter reporter;

        public LoadTagWordsAction(IFileReader fileReader, IDataProcessor dataProcessor, KeywordsStorage keywordsStorage, IReporter reporter)
        {
            this.fileReader = fileReader;
            this.dataProcessor = dataProcessor;
            this.keywordsStorage = keywordsStorage;
            this.reporter = reporter;
        }

        public string Category { get; } = "Загрузить";
        public string Name { get; } = "Слова тегов";
        public string Description { get; } = "Загрузить файл со словами";

        public void Perform()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Result.Of(() => fileReader.Read(dialog.FileName))
                .Then(dataProcessor.SelectTagPhrases)
                .Then(phrases => keywordsStorage.LoadKeywords(phrases))
                .RefineError("Failed to load word tags")
                .OnFail(reporter.Report);
        }
    }
}
