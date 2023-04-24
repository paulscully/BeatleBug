using BeatleBug.Models;
using BeatleBug.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatleBug.Services
{
    public interface IBugService
    {
        Task<BugResponseDto> GetSingleBug(int id);
        Task<IEnumerable<BugResponseDto>> GetAllBugsByType(int bugType);
        bool CloseSingleBug(int id);
        Task<int> CreateBug(BugDto bugDto);
        List<SeverityResponseDto> GetSeverityDetails();
        List<StatusResponseDto> GetStatusDetails();
    }
}
