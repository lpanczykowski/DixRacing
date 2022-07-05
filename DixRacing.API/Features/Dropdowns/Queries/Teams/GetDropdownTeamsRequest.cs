using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Dropdowns.Queries.Teams
{
    public record GetDropdownTeamsRequest (int EventId) : IRequest <GetDropdownResponse>
    {
        
    }
}