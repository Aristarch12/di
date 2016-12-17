using System;
using System.IO;
using System.Windows.Forms;

namespace TagsCloudApp.Actions
{
    class SaveImageAction : IUiAction
    {
        private readonly Canvas canvas;

        public SaveImageAction(Canvas canvas)
        {
            this.canvas = canvas;
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
                canvas.SaveImage(dialog.FileName);
        }
    }
}
