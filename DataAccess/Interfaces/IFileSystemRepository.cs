
namespace DataAccess.Interfaces
{
    public interface IFileSystemRepository
    {
        string CreateFileDestination(string boardName, string threadName);
        string GenerateFilePath(string baseFolder, string fileName, string fileExtension);
        Task WriteImageToDestination(string destination, byte[] data);
    }
}
