using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Events.Queries
{
    public interface IGetEventTeamsWithDriversQuery
    {
        Task<IList<EventTeamsWithDriversReadModel>> ExecuteAsync(int eventId);
    }
}