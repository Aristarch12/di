using System;
using System.Windows.Forms;
using TagsCloudApp.DataProcessors;
using TagsCloudApp.FileReaders;

namespace TagsCloudApp.Actions
{
    class LoadBoringWordsAction : IUiAction
    {
        private readonly IFileReader fileReader;
        private readonly IDataProcessor dataProcessor;
        private readonly BoringWordsStorage storage;

        public LoadBoringWordsAction(IFileReader fileReader, IDataProcessor dataProcessor, BoringWordsStorage storage)
        {
            this.fileReader = fileReader;
            this.dataProcessor = dataProcessor;
            this.storage = storage;
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
            var data = fileReader.Read(dialog.FileName);
            var phrases = dataProcessor.SplitWords(data);
            storage.LoadBoringWords(phrases);
        }
    }
}