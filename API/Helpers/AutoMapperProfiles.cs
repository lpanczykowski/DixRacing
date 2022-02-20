using API.Features.Events.Queries.GetAllEvents;
using API.Features.Races;
using AutoMapper;
using DixRacing.Domain.Events;
using DixRacing.Domain.Events.Queries;
using DixRacing.Domain.Races;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<EventCaptionReadModel, EventDto>();
            CreateMap<Race,GetRacesByRoundIdResponse>();
        }

    }
}