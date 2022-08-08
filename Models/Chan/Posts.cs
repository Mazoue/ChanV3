using Newtonsoft.Json;

namespace Models.Chan
{
    public class Posts
    {
        [JsonProperty("posts")]
        public List<Post> PostCollection { get; set; }
    }
}
