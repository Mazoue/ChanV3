using Models.Chan;

namespace DataAccess.Interfaces
{
    public interface IPostRepository
    {
        Task<Posts> GetPostsByBoardAndThreadId(string boardId, int threadId);
    }
}
