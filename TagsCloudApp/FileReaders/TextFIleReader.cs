using System.IO;

namespace TagsCloudApp.FileReaders
{
    class TextFIleReader : IFileReader
    {
        public string Read(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
