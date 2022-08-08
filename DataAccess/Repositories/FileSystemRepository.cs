using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class FileSystemRepository : IFileSystemRepository
    {
        private readonly string _baseFolder;
        public FileSystemRepository(string baseFolder) => _baseFolder = baseFolder;
        public string CreateFileDestination(string boardName, string threadName)
        {
            //Base Folder
            System.IO.Directory.CreateDirectory(_baseFolder);

            //Base Folder + BoardName
            var baseFolderBoardName = Path.Combine(_baseFolder, boardName);
            System.IO.Directory.CreateDirectory(baseFolderBoardName);

            //Base Folder + BoardName + ThreadName
            var baseFolderBoardNameThreadName = Path.Combine(baseFolderBoardName, threadName);
            System.IO.Directory.CreateDirectory(baseFolderBoardNameThreadName);

            return baseFolderBoardNameThreadName;

        }
        public string GenerateFilePath(string baseFolder, string fileName, string fileExtension)
        {
            var postNameAndExtension = $"{fileName}{fileExtension}";
            var filePath = Path.Combine(baseFolder, postNameAndExtension);
            return filePath;
        }

        public async Task WriteImageToDestination(string destination, byte[] data) => await File.WriteAllBytesAsync(destination, data);
    }
}
