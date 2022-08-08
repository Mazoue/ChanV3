using Models.Chan;

namespace Models.Downloads
{
    public class BoardDownloadRequest
    {
        public List<Catalogue?> Catalogues { get; set; }
        public string BoardId { get; set; }
    }
}
