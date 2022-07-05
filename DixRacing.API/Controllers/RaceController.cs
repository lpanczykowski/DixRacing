using API.Features.Races.Command.GetRaceConfirmationByIdAndUserId;
using API.Features.Races.Command.RaceConfirmationByIdAndUserId;
using API.Features.Races.Queries.GetRaceResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    //[Authorize]
    public class RaceController : BaseApiController
    {
        public RaceController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPut]
        public async Task<IActionResult> AddRace()
        {
            throw new NotImplementedException();

        }
        [HttpDelete("{raceId}")]
        public async Task<ActionResult<bool>> DeleteRace(int raceId)
        {
            throw new NotImplementedException();

        }

        [HttpPost]
        public async Task<ActionResult<bool>> UpdateRace()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{raceId}")]
        public async Task<IActionResult> FindRaceById(int raceId)
        {
            throw new NotImplementedException();

        }
        
        [HttpPost("raceStatus")]
        public async Task<IActionResult> RaceStatus()
        {
            throw new NotImplementedException();

        }
        [HttpGet("{raceId:int}/results/{sessionType}")]
        public async Task<ActionResult<IEnumerable<GetRaceResultsResponse>>> RaceResults(int raceId, string sessionType)
         => await SendAsync(new GetRaceResultsRequest(raceId, sessionType));
        [HttpPost("confirmation")]
        public async Task<ActionResult<bool>> RaceConfirmation([FromQuery] int raceId, int userId)
            => await SendAsync(new RaceConfirmationByIdAndUserIdCommand(raceId, userId));

        [HttpGet("confirmation")]
        public async Task<ActionResult<bool>> GetRaceConfirmation([FromQuery] int raceId, int userId)
            => await SendAsync(new GetRaceConfirmationByIdAndUserIdCommand(raceId, userId));


    }

}