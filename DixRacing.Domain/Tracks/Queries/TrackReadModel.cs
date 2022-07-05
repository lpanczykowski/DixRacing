using System;

namespace DixRacing.Domain.Tracks.Queries;


public record TrackReadModel(
    byte[] Photo,
    string Name 
)
{
    [Obsolete("For dapper support only")]
    public TrackReadModel() : this(default, default)
    {
    }

        
}