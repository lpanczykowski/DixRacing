using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class RaceController : BaseApiController
    {
        public RaceController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPut("add")]
        public async Task<IActionResult> AddRace()
        {
            throw new NotImplementedException();

        }
        [HttpDelete("delete/{raceId}")]
        public async Task<ActionResult<bool>> DeleteRace(int raceId)
        {
            throw new NotImplementedException();

        }
        [HttpGet("{raceId}")]
        public async Task<ActionResult<IActionResult>> FindRaceById(int raceId)
        {
            throw new NotImplementedException();

        }

        [HttpPost("raceStatus")]
        public async Task<ActionResult<IActionResult>> RaceStatus()
        {
            throw new NotImplementedException();

        }

    }

}