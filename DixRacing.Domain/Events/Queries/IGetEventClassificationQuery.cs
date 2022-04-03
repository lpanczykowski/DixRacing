using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Events.Queries
{
    public interface IGetEventClassificationQuery
    {
        public Task<ICollection<EventClassificationReadModel>> ExecuteAsync(int eventId);

    }
}