using DixRacing.Domain.Rounds.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Features.Events.Queries.GetAllEvents
{

    public record GetAllEventsResponse(IEnumerable<EventDto> Events);

    public record EventDto(int Id, string Name, int AmountOfRounds, DateTime RoundDay, int RoundId, byte[] Photo,
        IEnumerable<RoundReadModel> Rounds)
    {
        public EventDto() : this(default,default,default,default,default,default,new List<RoundReadModel>())
        {
            
        }   
    };


}
