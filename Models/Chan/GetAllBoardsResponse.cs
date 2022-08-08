using Newtonsoft.Json;

namespace Models.Chan
{
    public class GetAllBoardsResponse
    {
        [JsonProperty("boards")]
        public Board[] Boards { get; set; }
    }
}
