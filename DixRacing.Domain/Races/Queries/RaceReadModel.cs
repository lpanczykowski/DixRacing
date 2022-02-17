using System;

namespace DixRacing.Domain.Races.Queries
{
    public record RaceReadModel
    (int Id,
    DateTime PraticeDate,
    int PracticeLength,
    DateTime QualiDate,
    int QualiLength,
    DateTime RaceDate,
    int RaceLength,
    DateTime SigningTime,
    int MaxPlayers )
    {
        [Obsolete("For dapper support only")]
        public RaceReadModel() : this(default,
                                      default,
                                      default,
                                      default,
                                      default,
                                      default,
                                      default,
                                      default,
                                      default)
        {
            
        }
    }
}