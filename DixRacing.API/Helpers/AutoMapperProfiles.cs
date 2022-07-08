using API.Features.Dropdowns.Queries;
using API.Features.Events.Queries.GetAllEvents;
using API.Features.Races;
using API.Features.Races.Queries.GetRaceResults;
using AutoMapper;
using DixRacing.Domain.Events;
using DixRacing.Domain.Events.Queries;
using DixRacing.Domain.Races;
using DixRacing.Domain.Races.Queries;
using DixRacing.Domain.Teams;
using DixRacing.Domain.Users.Queries;
using DixRacing.Domain.Utility;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<EventCaptionReadModel, EventDto>();
            CreateMap<Race,GetRacesByRoundIdResponse>();
            CreateMap<UserRaceResultReadModel,GetRaceResultsResponse>();
            CreateMap<RaceLapReadModel,LapDto>();
            CreateMap<RacePointsReadModel,RacePointsDto>();
            CreateMap<Team,DropdownDto>()
                .ForMember(destinationMember => destinationMember.Value,
                    memberOptions=>memberOptions.MapFrom(src => src.Name));
            CreateMap<Game,DropdownDto>()
                .ForMember(destinationMember => destinationMember.Value,
                    memberOptions=>memberOptions.MapFrom(src => src.Name));
            CreateMap<EventParticipantReadModel,DropdownDto>()
                .ForMember(destinationMember => destinationMember.Value,
                    memberOptions=>memberOptions.MapFrom(src => '#' + src.Number.ToString() + ' ' + src.Name + ' ' + src.Surname));
            CreateMap<Car,DropdownDto>()
                .ForMember(destinationMember => destinationMember.Value,
                    memberOptions=>memberOptions.MapFrom(src=>src.CarName));
        }

    }
}