using API.Features.Dropdowns.Queries;
using API.Features.Dropdowns.Queries.Games;
using API.Features.Dropdowns.Queries.Participants;
using API.Features.Dropdowns.Queries.Teams;
using API.Features.EventParticipants.Queries.Participants;
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

        [HttpGet("games")]
        public Task<ActionResult<GetDropdownResponse>> GetDropdownGames()
            => SendAsync(new GetDropdownGamesRequest());

        [HttpGet("participants")]
        public async Task<ActionResult<GetDropdownResponse>> GetParticipants([FromQuery] int eventId)
            => await SendAsync(new GetDropdownParticipantsRequest(eventId));    
        // [HttpGet("cars")]
        // public Task<ActionResult<GetDropdownResponse>> GetDropdownCars([FromQuery] int eventId)
        //     => SendAsync(new GetDropdownCarsRequest(eventId));
    }
}