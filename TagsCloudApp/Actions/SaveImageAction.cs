using System;
using System.IO;
using System.Windows.Forms;
using TagsCloudApp.Reporter;

namespace TagsCloudApp.Actions
{
    class SaveImageAction : IUiAction
    {
        private readonly Canvas canvas;
        private readonly IReporter reporter;

        public SaveImageAction(Canvas canvas, IReporter reporter)
        {
            this.canvas = canvas;
            this.reporter = reporter;
        }

        public string Category { get; } = "Изображение";
        public string Name { get; } = "Сохранить";
        public string Description { get; } = "Сохранить изображение";
        public void Perform()
        {
            var dialog = new SaveFileDialog
            {
                CheckFileExists = false,
                DefaultExt = "bmp",
                FileName = "image.bmp",
                Filter = "Изображения (*.bmp)|*.bmp"
            };
            var res = dialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                Result.OfAction(() => canvas.SaveImage(dialog.FileName))
                    .RefineError("Failed to save the file")
                    .OnFail(reporter.Report);
            }
        }
    }
}
