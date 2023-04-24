using BeatleBug.Models;

namespace BeatleBug.Repository
{
    public interface IBugRepository
    {
        public Task<IEnumerable<Bug>> GetBugsByType(int statusId);

        public Task<Bug?> GetSingleBug(int id);

        public Task<int> CreateBug(Bug bug);

        public Task<bool> CloseBug(Bug bug);
    }
}