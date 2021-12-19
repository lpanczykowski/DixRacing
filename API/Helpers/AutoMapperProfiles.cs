using AutoMapper;
using DixRacing.Core.Models.Request;
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
            CreateMap <AddRoundRequest, Rounds>();
        }

    }
}