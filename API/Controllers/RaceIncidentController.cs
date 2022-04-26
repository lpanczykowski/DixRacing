using API.Features.RaceIncidents.Commands.CreateRaceIncident;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class RaceIncidentController : BaseApiController
    {
        public RaceIncidentController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateRaceIncident([FromBody] CreateRaceIncidentCommand command) 
            => await SendAsync(command);
    }
}