using Models.Chan;

namespace Services.Interfaces
{
    public interface IThreadService
    {
        Task<Posts> GetPostsInThreads(string boardId, int threadId);
    }
}
