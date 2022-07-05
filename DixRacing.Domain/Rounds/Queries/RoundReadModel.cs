using DixRacing.Domain.Tracks.Queries;
using System;

namespace DixRacing.Domain.Rounds.Queries
{
    public record RoundReadModel(
        int Id,
        string ServerName,
        string ServerPassword,
        int RoundNumber,
        bool isActive,
        DateTime RoundDay,
        TrackReadModel Track
        )
    {
        [Obsolete("For dapper support only")]
        public RoundReadModel() : this(default, string.Empty, string.Empty, default, default, default,
            new TrackReadModel())
        {
        }
    }

}