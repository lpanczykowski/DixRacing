using DixRacing.Domain.Races.Queries;
using DixRacing.Domain.Teams.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Events.Queries
{
    public record EventTeamsWithDriversReadModel(int TeamId,
                                                string TeamName,
                                                List<TeamMemberReadModel> TeamMembers,
                                                int TeamCar,
                                                int TeamPoints)
    {
        public EventTeamsWithDriversReadModel():this(default,default,new List<TeamMemberReadModel>(),default,default)
        {
            
        }
    }
}