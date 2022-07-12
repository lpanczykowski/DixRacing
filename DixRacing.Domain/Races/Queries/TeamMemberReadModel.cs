using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Races.Queries
{
    public record TeamMemberReadModel(int SummedPoints, string UserName, string UserSurname)
    {
        public TeamMemberReadModel(): this(default,default,default)
        {
            
        }
    }
}