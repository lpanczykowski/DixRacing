using DixRacing.Domain.Rounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DixRacing.Domain.Events.Queries
{
    public record EventCaptionReadModel
    (int EventId,
     string EventName,
     int  AmountOfRounds,
     DateTime RoundDay,
     int RoundId,
     byte[] Photo)
    {
        public EventCaptionReadModel() : this(default,default,default,default,default,default)
        {

        }
    }
}
