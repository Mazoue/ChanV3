using Models.Chan;

namespace Services.Interfaces
{
    public interface IBoardService
    {
        Task<List<Board>> FetchDetailsForAllBoards();
        Task<IEnumerable<Catalogue>> GetBoardCatalogue(string boardId);
    }
}
