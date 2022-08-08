using DataAccess.Interfaces;
using Models.Chan;
using Services.Interfaces;

namespace Services.Services
{
    public class ThreadService : IThreadService
    {
        private readonly IPostRepository _postRepository;
        public ThreadService(IPostRepository postRepository) => _postRepository = postRepository;

        public async Task<Posts> GetPostsInThreads(string boardId, int threadId) => await _postRepository.GetPostsByBoardAndThreadId(boardId, threadId);
    }
}
