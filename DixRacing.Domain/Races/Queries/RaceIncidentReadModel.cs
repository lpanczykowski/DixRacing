using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Races.Queries
{
    public record RaceIncidentReadModel(int UserId, int PointPenalty)
    {
        public RaceIncidentReadModel():this(default,default)
        {
        }
    }
}