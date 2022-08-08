using Models.Chan;

namespace DataAccess.Interfaces
{
    public interface IBoardRepository
    {
        Task<GetAllBoardsResponse> GetAllBoards();

        Task<IEnumerable<Catalogue>> GetBoardCatalogue(string boardId);
    }
}
