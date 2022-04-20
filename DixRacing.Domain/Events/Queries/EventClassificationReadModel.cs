using DixRacing.Domain.Races.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Events.Queries
{
    public record EventClassificationReadModel(int EventId,
                                     int Position,
                                     int DriverNumber,
                                     string DriverName,
                                     string DriverSurname,
                                     string? TeamName,
                                     int Car,
                                     ICollection<RacePointsReadModel> RacePoints,
                                     double Points)
    {
        public EventClassificationReadModel() : this(default, default, default, default, default, default, default, new List<RacePointsReadModel>(), default)
        {

        }
    };
}