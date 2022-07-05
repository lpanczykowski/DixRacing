using System;

namespace DixRacing.Domain.Rounds.Queries
{
    public record RoundReadModel(
        int Id,
        int TrackId,
        string ServerName,
        string ServerPassword,
        int RoundNumber,
        bool isActive,
        DateTime RoundDay
        )
    {
        [Obsolete("For dapper support only")]
        public RoundReadModel() : this(default,default, string.Empty, string.Empty, default, default,default)
        {
        }
    }

}