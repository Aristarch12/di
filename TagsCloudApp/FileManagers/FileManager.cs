using System.Collections.Generic;

namespace TagsCloudApp.FileManagers
{
    class FileManager : IFileManager
    {
        private readonly Dictionary<FileType, string> registeredFiles;

        public FileManager()
        {
            registeredFiles = new Dictionary<FileType, string>();
        }
        public bool TryGetFile(FileType fileType, out string fileName)
        {
            return registeredFiles.TryGetValue(fileType, out fileName);
        }

        public void SetFile(FileType fileType, string fileName)
        {
            registeredFiles[fileType] = fileName;
        }

    }
}