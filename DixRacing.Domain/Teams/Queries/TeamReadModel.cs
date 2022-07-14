using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Teams.Queries
{
    public record TeamReadModel(int TeamId, string TeamName)
    {
        public TeamReadModel() : this(default,String.Empty)
        {
              
        }
    }
}