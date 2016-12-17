using TagsCloudApp.Settings;

namespace TagsCloudApp.Actions
{
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