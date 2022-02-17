using API.Features.Events.Queries.GetAllEvents;
using AutoMapper;
using DixRacing.Domain.Events.Queries;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<EventCaptionReadModel, EventDto>();
        }

    }
}