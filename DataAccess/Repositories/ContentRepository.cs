using DataAccess.Interfaces;
using System.Diagnostics;

namespace DataAccess.Repositories
{
    public class ContentRepository : IContentRepository
    {
        private readonly HttpClient _httpClient;

        public ContentRepository(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<byte[]?> GetImage(string fileUrl)
        {
            try
            {
                using var result = await _httpClient.GetAsync(fileUrl).ConfigureAwait(false);
                if(result.IsSuccessStatusCode)
                {

                    return await result.Content.ReadAsByteArrayAsync();
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Stream> GetImageThumbnail(string boardId, string imageId) => await _httpClient.GetStreamAsync($"{boardId}/{imageId}s.jpg");
    }
}
