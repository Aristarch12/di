using System;
using TagsCloudApp.Reporter;
using TagsCloudApp.Settings;
using TagsCloudApp.TagGenerators;

namespace TagsCloudApp.Actions
{
    public class DrawingAction : IUiAction
    {
        private readonly Func<Canvas, ImageSettings, CloudPainter> cloudPainterFactory;
        private readonly Canvas canvas;
        private readonly KeywordsStorage keywordsStorage;
        private readonly ITagGenerator tagGenerator;
        private readonly ImageSettings imageSettings;
        private readonly IReporter reporter;

        public DrawingAction(Func<Canvas, ImageSettings, CloudPainter> cloudPainterFactory, Canvas canvas, KeywordsStorage keywordsStorage, ITagGenerator tagGenerator, ImageSettings imageSettings, IReporter reporter)
        {
            this.cloudPainterFactory = cloudPainterFactory;
            this.canvas = canvas;
            this.keywordsStorage = keywordsStorage;
            this.tagGenerator = tagGenerator;
            this.imageSettings = imageSettings;
            this.reporter = reporter;
        }

        public string Category { get; } = "Изображение";
        public string Name { get; } = "Нарисовать";
        public string Description { get; } = "Нарисовать настроенное облоко";
        public void Perform()
        {
            tagGenerator.GetTags(keywordsStorage.GetKeywords(), imageSettings.Center)
                .Then(cloudPainterFactory(canvas, imageSettings).Paint)
                .RefineError("Failed to draw a tag cloud")
                .OnFail(reporter.Report);
        }
    }

}