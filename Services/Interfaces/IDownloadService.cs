namespace Services.Interfaces
{
    public interface IDownloadService
    {
        Task<Stream> GetImageThumbnailAsync(string boardId, string imageId);
        string CleanInput(string input);
        Task DownloadFileAsync(string fileUrl, string destination);
        string CreateFileDestination(string boardId, string threadName);
        string GenerateFilePath(string baseFolder, string fileName, string fileExtension);
    }
}
