using API.Features.Dropdowns.Queries;
using API.Features.Dropdowns.Queries.Teams;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class DropdownController : BaseApiController
    {
        public DropdownController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("teams")]
        public Task<ActionResult<GetDropdownResponse>> GetDropdownTeams([FromQuery] int eventId)
            => SendAsync(new GetDropdownTeamsRequest(eventId));
        
    }
}