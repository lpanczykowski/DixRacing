using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Features.Events.Queries.GetAllEvents
{

    public record GetAllEventsResponse(IEnumerable<EventDto> Events);

    public record EventDto(int EventId, string Name, int AmountOfRounds, DateTime RoundDay, int RoundId, byte[] Photo);


}
