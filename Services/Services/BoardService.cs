using DataAccess.Interfaces;
using Models.Chan;
using Services.Interfaces;

namespace Services.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;
        public BoardService(IBoardRepository boardRepository) => _boardRepository=boardRepository;

        public async Task<List<Board>> FetchDetailsForAllBoards()
        {
            var boards = await _boardRepository.GetAllBoards();
            return boards.Boards.ToList();
        }

        public async Task<IEnumerable<Catalogue>> GetBoardCatalogue(string boardId) => await _boardRepository.GetBoardCatalogue(boardId);
    }
}
