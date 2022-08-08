using DataAccess.Interfaces;
using Models.Chan;
using Models.Exceptions;
using Newtonsoft.Json;

namespace DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly HttpClient _httpClient;

        public PostRepository(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<Posts> GetPostsByBoardAndThreadId(string boardId, int threadId)
        {
            var responseBody = await _httpClient.GetStringAsync($"{boardId}/thread/{threadId}.json");
            return JsonConvert.DeserializeObject<Posts>(responseBody) ?? throw new InvalidDeserializationException("Unable to deserialize Get Posts By Board And Thread Id response.");
        }
    }
}
