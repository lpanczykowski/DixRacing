using API.Features.Events.Commands.CreateEvent;
using API.Features.Events.Commands.UpdateEvent;
using API.Features.Events.Queries.GetAllEvents;
using API.Features.Events.Queries.GetEventWithRounds;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    //[Authorize(AuthenticationSchemes =
    //JwtBearerDefaults.AuthenticationScheme)]
    public class EventController : BaseApiController
    {
        public EventController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        public Task<ActionResult<GetAllEventsResponse>> GetAll()
            => SendAsync(new GetAllEventsRequest());
        [HttpGet("{eventId}/rounds")]
        public Task<ActionResult<GetEventWithRoundsByEventIdResponse>>  GetEventWithRounds(int eventId) 
            => SendAsync(new GetEventWithRoundsByEventIdRequest(eventId)); 
        [HttpPost]
        public Task<ActionResult<int>> Create([FromBody] CreateEventCommand command) 
            => SendAsync(command);
        [HttpPut]
        public Task<ActionResult<int>> Update([FromBody] UpdateEventCommand command)
            => SendAsync(command);
        //[HttpPut("sign")]
        //public async Task<ActionResult<bool>> SignForEvent(SignForEventRequest signForEventRequest)
        //{
        //    var response = await _signForEvent.SignUserForEventAsync(signForEventRequest);
        //    return Ok(response);
        //}
        //[HttpDelete("resign")]
        //public async Task<ActionResult<bool>> ResignFromEvent(ResignFromEventRequest resignFromEventRequest)
        //{
        //    var response = await _resignFromEvent.ResignFromEventAsync(resignFromEventRequest);
        //    return Ok(response);
        //}
        //[HttpPut("add")]
        //public async Task<ActionResult<Events>> AddEvent(AddEventRequest addEventRequest)
        //{
        //    Events events = new()
        //    {
        //        GameId = addEventRequest.GameId,
        //        Name = addEventRequest.Name,

        //    };
        //    await _eventRepository.AddAsync(events);
        //    return Ok(events);
        //}
        //[HttpDelete("remove/{eventId}")]
        //public async Task<ActionResult<bool>> RemoveEvent(int eventId)
        //{
        //    var raceEvent = await _eventRepository.FindEventByIdAsync(eventId);
        //    return Ok(await _eventRepository.DeleteAsync(raceEvent));
        //}
        //[HttpGet("{eventId}")]
        //public async Task<ActionResult<Events>> FindEventById(int eventId)
        //{
        //    var raceEvent = await _eventRepository.FindEventByIdAsync(eventId);
        //    return Ok(raceEvent);

        //}

        //[HttpGet("all")]
        //public async Task<ActionResult<ICollection<Events>>> GetAllEvents()
        //{
        //    var events = await _eventRepository.GetAllAsync();
        //    return Ok(events);
        //}
        //[HttpGet("all/activeRound")]
        //public async Task<ActionResult<ICollection<GetEventsWithActiveRound>>> GetAllEventsWithActiveRound()
        //{
        //    var events = await _eventService.GetEventsWithActiveRound();
        //    return Ok(events);
        //}

        //[HttpPost("changeCar")]
        //public async Task<ActionResult<bool>> ChangeCar(CarChangeRequest carChangeRequest)
        //{
        //    var eventParticipant = await _eventParticipantsRepository.FindEventParticipantsByEventIdAndUserId(carChangeRequest.EventId, carChangeRequest.UserId);
        //    if (eventParticipant == null)
        //    {
        //        return BadRequest("Cannot change car for null Id");
        //    }
        //    eventParticipant.Car = carChangeRequest.Car;
        //    var response = await _eventParticipantsRepository.UpdateAsync(eventParticipant);
        //    return Ok(response);
        //}

        //[HttpGet("{eventId}/participants")]
        //public async Task<ICollection<GetEventParticipantsResponse>> GetEventParticipantsResponsesByEventId(int eventId)
        //{
        //    var response = await _eventService.GetEventParticipantsResponsesByEventId(eventId);
        //    return response;
        //}

        //[HttpGet("{eventId}/rounds")]
        //public async Task<ICollection<GetEventRoundsResponse>> GetEventRoundsResponsesByEventId(int eventId)

        //{
        //    var response = await _roundService.GetEventRoundsResponsesByEventId(eventId);
        //    return response;
        //}

    }

}