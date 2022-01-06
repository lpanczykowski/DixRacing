using AutoMapper;
using DixRacing.Core.Models.Request;
using DixRacing.Core.Models.Response;
using DixRacing.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddRoundRequest, Rounds>();
            CreateMap<RaceResults,RaceResultsResponse>()
            .ForMember(destinationMember => destinationMember.Nickname, memberOptions => memberOptions.MapFrom(src=>src.User.Nick))
            .ForMember(destinationMember => destinationMember.Name, memberOptions => memberOptions.MapFrom(src=>src.User.Name))
            .ForMember(destinationMember =>destinationMember.Surname, memberOptions => memberOptions.MapFrom(src=>src.User.Surname));
            
        }

    }
}