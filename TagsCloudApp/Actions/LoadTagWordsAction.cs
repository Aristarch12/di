using System;
using System.Windows.Forms;
using TagsCloudApp.DataProcessors;
using TagsCloudApp.FileManagers;
using TagsCloudApp.FileReaders;
using TagsCloudApp.TagGenerators;

namespace TagsCloudApp.Actions
{
    class LoadTagWordsAction : IUiAction
    {
        private readonly IFileReader fileReader;
        private readonly IDataProcessor dataProcessor;
        private readonly KeywordsStorage keywordsStorage;

        public LoadTagWordsAction(IFileReader fileReader, IDataProcessor dataProcessor, KeywordsStorage keywordsStorage)
        {
            this.fileReader = fileReader;
            this.dataProcessor = dataProcessor;
            this.keywordsStorage = keywordsStorage;
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
            var data = fileReader.Read(dialog.FileName);
            var phrases = dataProcessor.SelectTagPhrases(data);
            keywordsStorage.LoadKeywords(phrases);
        }
    }
}
