using DixRacing.Domain.Events.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Events.Queries.GetEventTeamsWithDrivers
{
    public record GetEventTeamsWithDriversResponse(ICollection<EventTeamsWithDriversReadModel> EventTeamsWithDrivers);

}