namespace DataAccess.Interfaces
{
    public interface IContentRepository
    {
        Task<Stream> GetImageThumbnail(string boardId, string imageId);
        Task<byte[]?> GetImage(string fileUrl);
    }
}
