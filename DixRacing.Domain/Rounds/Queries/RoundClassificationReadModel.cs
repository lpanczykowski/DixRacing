using DixRacing.Domain.Races.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Rounds.Queries
{
    public record RoundClassificationReadModel(int RoundId, ICollection<RacePointsReadModel> RacePoints)
    {
        public RoundClassificationReadModel():this(default, new List<RacePointsReadModel>())
        {
        }
    }
}