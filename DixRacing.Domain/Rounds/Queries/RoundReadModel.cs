using System;

namespace DixRacing.Domain.Rounds.Queries
{
    public record RoundReadModel(
        int Id,
        string ServerName,
        string ServerPassword,
        int RoundNumber,
        bool isActive
        )
    {
        [Obsolete("For dapper support only")]
        public RoundReadModel() : this(default, string.Empty, string.Empty, default, default)
        {
        }
    }

}