using BeatleBug.Models;
using BeatleBug.Data;
using Microsoft.EntityFrameworkCore;

namespace BeatleBug.Repository
{
    public class BugRepository : IBugRepository
    {
        private readonly ApplicationDbContext _context;

        public BugRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<int> CreateBug(Bug bug)
        {
            await _context.AddAsync(bug);
            await _context.SaveChangesAsync();
            return bug.BugId;
        }

        public async Task<IEnumerable<Bug>> GetBugsByType(int statusId)
        {
            List<Bug> bugsList = (statusId < 1) ? await _context.Bugs.ToListAsync() :
                    await _context.Bugs.Where(b => b.StatusId == statusId).ToListAsync();

            return bugsList;
        }

        public async Task<Bug?> GetSingleBug(int id)
        {
            Bug? query = await _context.Bugs.FirstOrDefaultAsync(b => b.BugId == id);

            return query;
        }

        /// <summary>
        /// Not called
        /// </summary>
        /// <param name="bug"></param>
        /// <returns></returns>
        public async Task<bool> CloseBug(Bug bug)
        {
            if (await _context.Bugs.FindAsync(bug.BugId) != null) 
            { 
                _context.Bugs.Entry(bug).State = EntityState.Modified;
                _context.Bugs.Update(bug);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}