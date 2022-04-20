using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Races.Queries
{
    public record RaceResultReadModel(
        int RaceId,
        int UserId,
        int Position,
        int TotalTime
    )
    {
        public RaceResultReadModel() : this(default, default, default, default)
        {

        }
    }
}