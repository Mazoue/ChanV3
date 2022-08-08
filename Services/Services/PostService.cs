using Models.Downloads;
using Services.Interfaces;
using System.Linq;

namespace Services.Services
{
    public class PostService : IPostService
    {
        private readonly IDownloadService _downloadService;
        private readonly ILogService _logService;

        public PostService(IDownloadService downloadService, ILogService logService)
        {
            _downloadService = downloadService;
            _logService = logService;
        }
        public async Task<Stream> GetImageThumbnailAsync(string boardId, string imageId) => await _downloadService.GetImageThumbnailAsync(boardId, imageId);

        public IEnumerable<FileDownloadRequest> GenerateDownloads(DownloadRequest downloadRequest)
        {
            var fileDownloads = new List<FileDownloadRequest>();

            Parallel.ForEach(downloadRequest.Thread.Posts, post =>
            {
                if (!string.IsNullOrEmpty(post.filename) && !string.IsNullOrEmpty(post.ext))
                {
                    var baseFolder = BuildFolderStructure(downloadRequest.Thread.ThreadTitle, downloadRequest.Thread.BoardId).Trim();

                    var filePath = GenerateFilePath(baseFolder, post.filename, post.ext);

                    var fileUrl = $"{downloadRequest.Thread.BoardId}/{post.tim}{post.ext}";

                    fileDownloads.Add(new FileDownloadRequest()
                    {
                        PostNumber = post.no,
                        FileExtension = post.ext,
                        FileName = post.filename,
                        FileSize = post.fsize,
                        FilePath = filePath,
                        FileUrl = fileUrl
                    });
                }
            });

            return fileDownloads;
        }        

        public async IAsyncEnumerable<FileDownloadRequest> DownloadPostsAsync(IEnumerable<FileDownloadRequest> downloadRequests)
        {
            var rateLimit = new SemaphoreSlim(1);
            foreach (var downloadRequest in downloadRequests)
            {
                if (downloadRequest != null && !string.IsNullOrEmpty(downloadRequest.FileUrl) && !string.IsNullOrEmpty(downloadRequest.FilePath))
                {
                    await rateLimit.WaitAsync();

                    await _downloadService.DownloadFileAsync(downloadRequest.FileUrl, downloadRequest.FilePath);
                    await Task.Delay(1000);

                    rateLimit.Release();
                    yield return downloadRequest;
                }
            }
        }

        private string BuildFolderStructure(string? threadTitle, string boardId)
        {
            var threadName = !string.IsNullOrEmpty(threadTitle) ? _downloadService.CleanInput(threadTitle) : "No Title";
            var baseFolder = _downloadService.CreateFileDestination(boardId, threadName);
            return baseFolder;
        }

        private string GenerateFilePath(string baseFolder, string fileName, string fileExtension)
        {
            var postName = _downloadService.CleanInput(fileName);
            var filePath = _downloadService.GenerateFilePath(baseFolder, postName, fileExtension);
            return filePath;
        }       
    }
}
