using API.Features.RaceIncidents.Commands.CreateRaceIncident;
using API.Features.RaceIncidents.Commands.DeleteRaceIncident;
using API.Features.RaceIncidents.Commands.UpdateRaceIncident;
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

        [HttpPut]
        public async Task<ActionResult<int>> UpdateRaceIncident([FromBody] UpdateRaceIncidentCommand command)
            => await SendAsync(command);
        [HttpDelete]
        public async Task<ActionResult<int>> DeleteRaceIncident([FromBody] DeleteRaceIncidentCommand command)
            => await SendAsync(command);
    }
}