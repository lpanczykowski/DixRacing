using System;

namespace DixRacing.Domain.Tracks.Queries;


public record TrackReadModel(
    int Id,
    byte[] Photo,
    string Name 
)
{
    [Obsolete("For dapper support only")]
    public TrackReadModel() : this(default,default, default)
    {
    }

        
}