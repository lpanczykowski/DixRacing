using DixRacing.Domain.Rounds.Queries;
using System;
using System.Collections.Generic;

namespace DixRacing.Domain.Events.Queries
{
    public record EventReadModel(
        int Id,
        string Name,
        ICollection<RoundReadModel> Rounds)
    {
        [Obsolete("For dapper support only")]
        public EventReadModel() : this(default, string.Empty, new List<RoundReadModel>())
        {
        }
    }
}
