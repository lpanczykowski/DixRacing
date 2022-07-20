using DixRacing.Domain.Races.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Rounds.Queries
{
    public record RoundIncidentsReadModel(int RoundId, IList<RaceIncidentReadModel> raceIncidents)
    {
        public RoundIncidentsReadModel():this (default, new List<RaceIncidentReadModel>())
        {
        }
    }
}