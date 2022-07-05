using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API
{
    //[ServiceFilter(typeof(LogUserActivity))]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
        protected async Task<ActionResult<TResponse>> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}