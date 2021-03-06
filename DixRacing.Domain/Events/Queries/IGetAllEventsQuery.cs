using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DixRacing.Domain.Events.Queries
{
    public interface IGetAllEventsQuery
    {
        Task<IEnumerable<EventReadModel>> ExecuteAsync(bool onlyActiveEvents = false);
    }
}
