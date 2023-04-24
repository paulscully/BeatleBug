using BeatleBug.Common;
using BeatleBug.Common.Enums;
using BeatleBug.Models;
using BeatleBug.Models.Dtos;
using BeatleBug.Repository;

namespace BeatleBug.Services
{
    public class BugService : IBugService
    {
        private readonly IBugRepository _bugRepository;

        public BugService(IBugRepository bugRepository) 
        {
            _bugRepository = bugRepository;
        }

        public async Task<BugResponseDto> GetSingleBug(int id)
        {            
            var bug =  await _bugRepository.GetSingleBug(id);
            BugResponseDto bugResponseDto = new();

            if (bug != null)
            {
                var mapper = MapperConfig.InitializeAutomapper();

                bugResponseDto = mapper.Map<BugResponseDto>(bug);

                var enumStatus = (StatusEnum)bugResponseDto.StatusId;
                bugResponseDto.StatusDescription = enumStatus.GetDescription();

                var enumSeverity = (SeverityEnum)bugResponseDto.SeverityId;
                bugResponseDto.SeverityDescription = enumSeverity.GetDescription();
            }

            return bugResponseDto;
        }

        public async Task<IEnumerable<BugResponseDto>> GetAllBugsByType(int bugType)
        {
            var bugDtoList = new List<BugResponseDto>();

            var bugs = await _bugRepository.GetBugsByType(bugType);

            if (bugs != null)
            {
                var mapper = MapperConfig.InitializeAutomapper();

                bugDtoList = mapper.Map<List<BugResponseDto>>(bugs);
            }

            foreach (var bugDto in bugDtoList)
            {
                var enumStatus = (StatusEnum)bugDto.StatusId;
                bugDto.StatusDescription = enumStatus.GetDescription();

                var enumSeverity = (SeverityEnum)bugDto.SeverityId;
                bugDto.SeverityDescription = enumSeverity.GetDescription();
            }

            return bugDtoList;
        }

        public bool CloseSingleBug(int bugId)
        {
            // Not Implemented

            return false;
        }

        public async Task<int> CreateBug(BugDto bugDto)
        {
            var mapper = MapperConfig.InitializeAutomapper();

            Bug bug = new();
            bug = mapper.Map<Bug>(bugDto);

            int bugId = await _bugRepository.CreateBug(bug);

            return bugId;
        }

        public List<SeverityResponseDto> GetSeverityDetails()
        {
            List<SeverityResponseDto> response = new();

            foreach (SeverityEnum severityEnum in Enum.GetValues(typeof(SeverityEnum)))
            {
                var severity = new SeverityResponseDto
                {
                    SeverityId = (int)severityEnum,
                    SeverityDescription = severityEnum.GetDescription()
                };

                response.Add(severity);
            }

            return response;
        }

        public List<StatusResponseDto> GetStatusDetails()
        {
            List<StatusResponseDto> response = new();

            foreach (StatusEnum statusEnum in Enum.GetValues(typeof(StatusEnum)))
            {
                var status = new StatusResponseDto
                {
                    StatusId = (int)statusEnum,
                    StatusDescription = statusEnum.GetDescription()
                };

                response.Add(status); 
            }

            return response;
        }
    }
}
