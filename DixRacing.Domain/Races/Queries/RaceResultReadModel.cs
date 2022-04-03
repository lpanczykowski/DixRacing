using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Races.Queries
{
    public record RaceResultReadModel(double Points, double PenaltyPoints, int Position)
    {
        public RaceResultReadModel() : this(default, default, default)
        {

        }

    }
}