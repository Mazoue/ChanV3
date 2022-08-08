using Newtonsoft.Json;

namespace Models.Chan
{
    public class Catalogue
    {
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("Threads")]
        public ChanThread[] Threads { get; set; }
        public bool Checked { get; set; }
    }
}
