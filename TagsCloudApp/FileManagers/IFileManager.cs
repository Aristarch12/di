namespace TagsCloudApp.FileManagers
{
    interface IFileManager
    {
        bool TryGetFile(FileType fileType, out string fileName);

        void SetFile(FileType fileType, string fileName);
    }
}
