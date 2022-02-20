using API.Features.Races;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    //[Authorize]
    public class RoundController : BaseApiController
    {
        public RoundController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet("{roundId}/races")]
        public Task<ActionResult<IEnumerable<GetRacesByRoundIdResponse>>> GetRacesByRoundId(int roundId) => 
             SendAsync(new GetRacesByRoundIdCommand(roundId));

    }
}