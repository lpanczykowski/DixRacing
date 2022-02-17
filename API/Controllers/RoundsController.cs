using API.Features.Rounds.Queries.GetRoundWithRaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
   // [Authorize]
   public class RoundsController : BaseApiController
   {
        public RoundsController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet("{roundId}/races")]
        public Task<ActionResult<GetRoundWithRacesResponse>> GetRoundWithRaces(int roundId) 
            => SendAsync(new GetRoundWithRacesRequest(roundId));

    }
}