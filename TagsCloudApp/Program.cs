using System;
using System.Drawing;
using System.Reflection;
using Autofac;
using TagsCloudApp.Settings;
using TagsCloudApp.WordsPreprocessor;

namespace TagsCloudApp
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var client = CreateClient();
            client.Run();
        }

        private static IClient CreateClient()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(Program))).AsImplementedInterfaces();
            builder.RegisterType<BoringWordsStorage>().AsSelf().SingleInstance();
            builder.RegisterType<KeywordsStorage>().AsSelf().SingleInstance();
            builder.RegisterType<Canvas>().AsSelf().SingleInstance();
            builder.RegisterType<ApplicationWindow>().AsSelf();
            builder.RegisterType<Preprocessor>().AsSelf();
            builder.RegisterType<CloudPainter>().AsSelf();
            var imageSettings = new ImageSettings {Height = 500, Width = 500, TextColor = Color.Crimson, BackdgoundColor = Color.Lavender };
            builder.RegisterInstance(imageSettings).AsSelf().SingleInstance();
            var fontSettings = new FontSettings(FontFamily.GenericSerif, 18, 40);
            builder.RegisterInstance(fontSettings).As<FontSettings>().SingleInstance();
            var container = builder.Build();
            return container.Resolve<IClient>();
        }
    }
}
