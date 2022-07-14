using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Races.Queries
{
    public record RacePointsReadModel(int RaceId, int Position, int Points)
    {
        public RacePointsReadModel() : this(default, default, default)
        {

        }
    }
}