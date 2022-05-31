using API.Features.EventParticipants.Queries;
using API.Features.Events.Commands.CreateEvent;
using API.Features.Events.Commands.ResignFromEvent;
using API.Features.Events.Commands.SignForEvent;
using API.Features.Events.Commands.UpdateEvent;
using API.Features.Events.Queries.GetAllEvents;
using API.Features.Events.Queries.GetEventClassification;
using API.Features.Events.Queries.GetEventWithRounds;
using API.Infrastructure.Headers;
using DixRacing.Domain.Events.Queries;
using DixRacing.Domain.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class EventController : BaseApiController
    {
        public EventController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        public Task<ActionResult<GetAllEventsResponse>> GetAll()
            => SendAsync(new GetAllEventsRequest());
        [HttpGet("{eventId}/rounds")]
        public Task<ActionResult<GetEventWithRoundsByEventIdResponse>>  GetRounds(int eventId) 
            => SendAsync(new GetEventWithRoundsByEventIdRequest(eventId)); 
        [HttpPost]
        public Task<ActionResult<int>> Create([FromBody] CreateEventCommand command) 
            => SendAsync(command);
        [HttpPut]
        public Task<ActionResult<int>> Update([FromBody] UpdateEventCommand command)
            => SendAsync(command);
        [HttpPut("sign")]
        public Task<ActionResult<int>> SignForEvent([FromBody] SignForEventCommand command)
            => SendAsync(command);
        [HttpPut("resign")]
        public Task<ActionResult<bool>> ResignFromEvent([FromBody] ResignFromEventCommand command)
            => SendAsync(command);
        [HttpGet("{eventId}/participants")]
        public async Task<ActionResult<PaginatedResult<EventParticipantReadModel>>> GetParticipants(int eventId, [FromQuery] PaginationRequest request) 
            => await SendAsync(new GetParticipantsByEventIdRequest(new EventParticipantPaginatedRequest(){
                                                                   PageSize = request.PageSize,
                                                                   PageNumber = request.PageNumber,
                                                                   EventId = eventId
                                                                   }));
        [HttpGet("{eventId}/classification")]
        public async Task<ActionResult<GetEventClassificationResponse>> GetClassification(int eventId)
             => await SendAsync(new GetEventClassificationRequest(eventId));

    }

}