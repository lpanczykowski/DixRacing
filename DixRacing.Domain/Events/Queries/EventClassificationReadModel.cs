using DixRacing.Domain.Races.Queries;
using DixRacing.Domain.Rounds.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Events.Queries
{
    public record EventClassificationReadModel(int EventId,
                                     int Number,
                                     string Name,
                                     string Surname,
                                     string? TeamName,
                                     int Car,
                                     ICollection<RoundClassificationReadModel> RoundsPoints,
                                     int SummedPoints,
                                     double PointPenalty)
    {
        public EventClassificationReadModel() : this(default, default, default, default, default, default, new List<RoundClassificationReadModel>(), default, default)
        {

        }
    };
}