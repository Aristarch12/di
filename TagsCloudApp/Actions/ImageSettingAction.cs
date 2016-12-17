using System;
using System.Windows.Forms;
using TagsCloudApp.Settings;

namespace TagsCloudApp.Actions
{
    public class ImageSettingAction : IUiAction
    {
        private readonly Canvas canvas;
        private readonly ImageSettings imageSettings;

        public ImageSettingAction(Canvas canvas, ImageSettings imageSettings)
        {
            this.canvas = canvas;
            this.imageSettings = imageSettings;
        }
        public string Category => "Настройки";
        public string Name => "Изображение";
        public string Description => "Изменить параметры изображения";

        public void Perform()
        {
            SettingsForm.For(imageSettings).ShowDialog();
            canvas.RecreateImage(imageSettings);
        }
    }

    public class FontSizeAction : IUiAction
    {
        private readonly Canvas canvas;
        private readonly FontSettings fontSettings;


        public FontSizeAction(Canvas canvas, FontSettings fontSettings)
        {
            this.canvas = canvas;
            this.fontSettings = fontSettings;
        }
        public string Category => "Настройки";
        public string Name => "Размер шрифта";
        public string Description => "Изменить минимальный и максимальный размер шрифта";

        public void Perform()
        {
            SettingsForm.For(fontSettings).ShowDialog();
        }
    }
}
