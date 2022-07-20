using API.Features.RaceIncidents.Commands.AppealRaceIncident;
using API.Features.RaceIncidents.Commands.CreateRaceIncident;
using API.Features.RaceIncidents.Commands.DeleteRaceIncident;
using API.Features.RaceIncidents.Commands.UpdateRaceIncident;
using API.Features.RaceIncidents.Queries.GetRaceIncidentsByRoundId;
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
        [HttpPost("add")]
        public async Task<ActionResult<int>> CreateRaceIncident([FromBody] CreateRaceIncidentCommand command)
            => await SendAsync(command);

        [HttpPut("solve")]
        public async Task<ActionResult<int>> UpdateRaceIncident([FromBody] UpdateRaceIncidentCommand command)
            => await SendAsync(command);
        [HttpDelete("delete")]
        public async Task<ActionResult<int>> DeleteRaceIncident([FromBody] DeleteRaceIncidentCommand command)
            => await SendAsync(command);
        [HttpPut("appeal")]
        public async Task<ActionResult<int>> AppealRaceIncident([FromBody] AppealRaceIncidentCommand command)
            => await SendAsync(command);
        [HttpGet("{roundId}")]
        public async Task<ActionResult<GetRaceIncidentsByRoundIdResponse>> GetIncidents(int roundId)
            => await SendAsync(new GetRaceIncidentsByRoundIdRequest(roundId));
    }
}