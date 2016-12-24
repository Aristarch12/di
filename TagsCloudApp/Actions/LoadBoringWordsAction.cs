using System;
using System.Windows.Forms;
using TagsCloudApp.DataProcessors;
using TagsCloudApp.FileReaders;
using TagsCloudApp.Reporter;

namespace TagsCloudApp.Actions
{
    class LoadBoringWordsAction : IUiAction
    {
        private readonly IFileReader fileReader;
        private readonly IDataProcessor dataProcessor;
        private readonly BoringWordsStorage storage;
        private readonly IReporter reporter;

        public LoadBoringWordsAction(IFileReader fileReader, IDataProcessor dataProcessor, BoringWordsStorage storage, IReporter reporter)
        {
            this.fileReader = fileReader;
            this.dataProcessor = dataProcessor;
            this.storage = storage;
            this.reporter = reporter;
        }
        public string Category { get; } = "Загрузить";
        public string Name { get; } = "Скучные слова";
        public string Description { get; } = "Загрузить файл скучных слов";
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
                .Then(p => storage.LoadBoringWords(p))
                .RefineError("Failed to load boring words")
                .OnFail(reporter.Report);
        }
    }
}