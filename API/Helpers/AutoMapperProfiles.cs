using AutoMapper;
using DixRacing.Data.Dtos;
using DixRacing.Data.Entites;
using DixRacing.Data.Models.Request;
using DixRacing.Data.Models.Response;
using System.Linq;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddRoundRequest, Rounds>();
            CreateMap<RaceResults, RaceResultsResponse>()
                .ForMember(destinationMember => destinationMember.Nickname, memberOptions => memberOptions.MapFrom(src => src.User.Nick))
                .ForMember(destinationMember => destinationMember.Name, memberOptions => memberOptions.MapFrom(src => src.User.Name))
                .ForMember(destinationMember => destinationMember.Surname, memberOptions => memberOptions.MapFrom(src => src.User.Surname));

            CreateMap<Events, GetEventsWithActiveRound>()
                .ForMember(destinationMember => destinationMember.RoundCounter, memberOptions=>memberOptions.MapFrom(src=>src.Rounds.Count()))
                .ForMember(destinationMember => destinationMember.ActiveRound, memberOptions => memberOptions.MapFrom(src=>src.Rounds.Where(x=>x.isActive).FirstOrDefault()));
            CreateMap<Users,ParticipantDto>();    
            CreateMap<Rounds,GetEventRoundsResponse>();      
            CreateMap<Races,GetRacesByRoundIdResponse>();           

        }

    }
}