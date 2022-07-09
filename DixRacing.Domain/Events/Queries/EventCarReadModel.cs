using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Events.Queries
{
    public record EventCarReadModel(int Id, string CarName)
    {
        public EventCarReadModel() : this(default,default)
        {
        }
    }
}