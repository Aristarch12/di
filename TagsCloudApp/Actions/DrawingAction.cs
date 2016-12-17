using TagsCloudApp.Settings;
using TagsCloudApp.TagGenerators;

namespace TagsCloudApp.Actions
{
    public class DrawingAction : IUiAction
    {
        private readonly Canvas canvas;
        private readonly KeywordsStorage keywordsStorage;
        private readonly ITagGenerator tagGenerator;
        private readonly ImageSettings imageSettings;

        public DrawingAction(Canvas canvas, KeywordsStorage keywordsStorage, ITagGenerator tagGenerator, ImageSettings imageSettings)
        {
            this.canvas = canvas;
            this.keywordsStorage = keywordsStorage;
            this.tagGenerator = tagGenerator;
            this.imageSettings = imageSettings;
        }

        public string Category { get; } = "Изображение";
        public string Name { get; } = "Нарисовать";
        public string Description { get; } = "Нарисовать настроенное облоко";
        public void Perform()
        {
            var tags = tagGenerator.GetTags(keywordsStorage.GetKeywords(), imageSettings.Center);
            new CloudPainter(canvas, imageSettings).Paint(tags);
        }
    }
}