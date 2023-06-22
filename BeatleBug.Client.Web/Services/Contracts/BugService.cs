using BeatleBug.Models.Dtos;
using System.Net.Http.Json;

namespace BeatleBug.Client.Web.Services.Contracts
{
    public class BugService : ClientApi, IBugService
    {
        private readonly HttpClient _httpClient;

        public BugService(HttpClient http) : base("Bug", http) 
        { 
            _httpClient = http;
        }

        public async Task<IEnumerable<BugResponseDto>> GetBugs(int id)
        {
            try
            {
                var bugList = await GetAsync<IEnumerable<BugResponseDto>>($"list/statusId?id={id}");
                return bugList ?? new List<BugResponseDto>();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<StatusResponseDto>> GetStatus()
        {
            try
            {
                var bugStatus = await GetAsync<IEnumerable<StatusResponseDto>>("list/status");
                return (bugStatus != null) ? bugStatus.ToList() : new List<StatusResponseDto>();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<int> CreateBug(BugDto bugDto)
        {
            try
            {
                var bugId = await PostAsync<int, BugDto>("", bugDto);
                return bugId;
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }
    }
}
