using DataAccess.Interfaces;
using Services.Interfaces;
using System.Text.RegularExpressions;

namespace Services.Services
{
    public class DownloadService : IDownloadService
    {
        private readonly IContentRepository _contentRepository;
        private readonly IFileSystemRepository _fileSystemRepository;

        public DownloadService(IContentRepository contentRepository, IFileSystemRepository fileSystemRepository)
        {
            _contentRepository = contentRepository;
            _fileSystemRepository = fileSystemRepository;
        }
        public async Task<Stream> GetImageThumbnailAsync(string boardId, string imageId) => await _contentRepository.GetImageThumbnail(boardId, imageId);

        public async Task DownloadFileAsync(string fileUrl, string destination)
        {
            var imageResponse = await _contentRepository.GetImage(fileUrl);

            if(imageResponse != null)
            {
                await _fileSystemRepository.WriteImageToDestination(destination, imageResponse);
            }
        }

        public string CreateFileDestination(string boardId, string threadName)
        {
            threadName = FormatThreadTitle(threadName);
            return _fileSystemRepository.CreateFileDestination(boardId, threadName);
        }

        public string GenerateFilePath(string baseFolder, string fileName, string fileExtension) => _fileSystemRepository.GenerateFilePath(baseFolder, fileName, fileExtension);

        public string CleanInput(string input)
        {
            // Replace invalid characters with empty strings.
            try
            {
                return Regex.Replace(input, @"[^\w\.@-]", "",
                    RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            // If we timeout when replacing invalid characters, 
            // we should return Empty.
            catch(RegexMatchTimeoutException)
            {
                return string.Empty;
            }
        }

        private string FormatThreadTitle(string input)
        {
            if(input.Contains("2f"))
                input = input.Replace("2f", " ");
            if(input.Contains("2c"))
                input = input.Replace("2c", " ");

            input = input.Trim();

            return input;
        }
    }
}
