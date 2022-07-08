using API.Extensions;
using API.Features.EventParticipants.Queries.GetParticipantByEventId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers;

public class EventParticipantController : BaseApiController
{
    public EventParticipantController(IMediator mediator) : base(mediator)
    {
        
    }

    [HttpGet]
    [Route("eventId/{eventId}")]
    public async Task<ActionResult<GetParticipantByEventIdResponse>> GetEventParticipantByEventIdAndUserId(int eventId) 
        => await SendAsync(new GetParticipantByEventIdRequest(eventId, User.GetUserId()));
}