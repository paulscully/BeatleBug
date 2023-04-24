using BeatleBug.Models.Dtos;
using BeatleBug.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeatleBug.WebApi.Controllers
{
    /*[Authorize]*/
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly IBugService _bugService;

        public BugController(IBugService bugService)
        {
            _bugService = bugService;
        }

        [HttpGet("{id}")]
        public async Task<BugResponseDto> GetBug(int id)
        {
            try
            { 
                var response = await _bugService.GetSingleBug(id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occurred: " + ex.Message);
            }
        }

        [HttpGet("list/statusId")]
        public async Task<IEnumerable<BugResponseDto>> ListBugs(int id)
        {
            var buglist = await _bugService.GetAllBugsByType(id);

            return buglist;
        }

        /*
        [HttpPut("{id}")]
        public HttpResponseMessage CloseBug(int id)
        {
            // Not Implemented 

            return new HttpResponseMessage();
        }
        */

        [Route("list/status")]
        [HttpGet]
        public List<StatusResponseDto> GetStatusDetails()
        {
            var statusDetails = _bugService.GetStatusDetails();

            return statusDetails;
        }

        [Route("list/severity")]
        [HttpGet]
        public List<SeverityResponseDto> GetSeverityDetails()
        {
            var severityDetails = _bugService.GetSeverityDetails();

            return severityDetails;
        }

        [HttpPost("")]
        public async Task<int> CreateBug(BugDto bugDto)
        {
            var bugId = await _bugService.CreateBug(bugDto);

            return bugId;
        }
    }
}
