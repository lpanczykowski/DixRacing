using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Races.Queries
{
    public record RaceLapReadModel(int Lap,
                                      int Split1,
                                      int Split2,
                                      int Split3,
                                      int IsValid)
    {
        public RaceLapReadModel() : this(default,
                                            default,
                                            default,
                                            default,
                                            default)
        {

        }

    }
}