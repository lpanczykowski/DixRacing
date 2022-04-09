using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Races.Queries
{
    public record RacePointReadModel(int Position, int Points)
    {
        public RacePointReadModel() : this(default, default)
        {

        }
    }
}