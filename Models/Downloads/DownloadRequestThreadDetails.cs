using Models.Chan;

namespace Models.Downloads
{
    public class DownloadRequestThreadDetails
    {
        public string ThreadTitle { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public string BoardId { get; set; }
    }
}
