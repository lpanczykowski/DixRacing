using DixRacing.Domain.Races.Queries;
using System;
using System.Collections.Generic;

namespace DixRacing.Domain.Rounds.Queries
{
    public record RoundWithRacesReadModel(

        int Id,
        ICollection<RaceReadModel> Races 
    )
    {
        [Obsolete("For dapper support only")]
        public RoundWithRacesReadModel() : this(default, new List<RaceReadModel>())
        {
        }

        
    }

}