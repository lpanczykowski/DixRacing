using System;

namespace DixRacing.Domain.Events.Queries
{
    public record EventParticipantReadModel(int Car,int Number,string Team,string Name,string Surname,string Nick)
    {
        [Obsolete("For dapper support only")]
        public EventParticipantReadModel() : this(default,default,default,default,default,default)
        {
        }
    }
}