using AutoMapper;
using BeatleBug.Models;
using BeatleBug.Models.Dtos;

namespace BeatleBug.Common
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Configuring Models to Dtos
                cfg.CreateMap<Bug, BugResponseDto>();
                cfg.CreateMap<BugDto, Bug>();
                cfg.CreateMap<CommentsDto, Comment>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
