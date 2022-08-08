namespace Models.Downloads
{
    public class FileDownloadRequest
    {
        public string FileUrl { get; set; }
        public string FilePath { get; set; }
        public int PostNumber { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int FileSize { get; set; }
    }
}
