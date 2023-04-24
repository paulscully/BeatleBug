using BeatleBug.Models.Dtos;

namespace BeatleBug.Client.Web.Services.Contracts
{
    public interface IBugService
    {
        Task<IEnumerable<BugResponseDto>> GetBugs(int id);
        Task<IEnumerable<StatusResponseDto>> GetStatus();
        Task<int> CreateBug(BugDto bugDto);
    }
}
