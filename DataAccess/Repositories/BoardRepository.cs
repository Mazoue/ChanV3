using DataAccess.Interfaces;
using Models.Chan;
using Models.Exceptions;
using Newtonsoft.Json;

namespace DataAccess.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly HttpClient _httpClient;

        public BoardRepository(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<GetAllBoardsResponse> GetAllBoards()
        {
            var responseBody = await _httpClient.GetStringAsync($"boards.json");
            return JsonConvert.DeserializeObject<GetAllBoardsResponse>(responseBody) ?? throw new InvalidDeserializationException("Unable to deserialize Get All Boards response.");
        }

        public async Task<IEnumerable<Catalogue>> GetBoardCatalogue(string boardId)
        {
            var responseBody = await _httpClient.GetStringAsync($"/{boardId}/catalog.json");
            return JsonConvert.DeserializeObject<IEnumerable<Catalogue>>(responseBody)  ?? throw new InvalidDeserializationException("Unable to deserialize Get Board Catalogue response.");
        }
    }
}
