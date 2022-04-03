using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Teams.Queries
{
    public record TeamReadModel(string Name)
    {
        public TeamReadModel() : this(String.Empty)
        {
              
        }
    }
}