using DixRacing.Core;
using DixRacing.Core.Models.Request;
using DixRacing.Core.Models.Response;
using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using DixRacing.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class EventController : BaseApiController
    {
        private readonly ISignForEvent _signForEvent;
        private readonly IResignFromEvent _resignFromEvent;
        private readonly IEventRepository _eventRepository;
        private readonly IEventParticipantsRepository _eventParticipantsRepository;

        public EventController(ISignForEvent signForEvent,
                               IResignFromEvent resignFromEvent,
                               IEventRepository eventRepository,
                               IEventParticipantsRepository eventParticipantsRepository
                            )
        {
            _signForEvent = signForEvent;
            _resignFromEvent = resignFromEvent;
            _eventRepository = eventRepository;
            _eventParticipantsRepository=eventParticipantsRepository;
            
        }

        [HttpPut("sign")]
        public async Task<ActionResult<bool>> SignForEvent(SignForEventRequest signForEventRequest)
        {
            var response = await _signForEvent.SignUserForEventAsync(signForEventRequest);
            return Ok(response);
        }
        [HttpDelete("resign")]
        public async Task<ActionResult<bool>> ResignFromEvent(ResignFromEventRequest resignFromEventRequest)
        {
            var response = await _resignFromEvent.ResignFromEventAsync(resignFromEventRequest);
            return Ok(response);
        }
        [HttpPut("add")]
        public async Task<ActionResult<Events>> AddEvent(AddEventRequest addEventRequest)
        {
            Events events = new()
            {
                GameId = addEventRequest.GameId,
                Name = addEventRequest.Name,

            };
            await _eventRepository.AddAsync(events);
            return Ok(events);
        }
        [HttpDelete("remove/{eventId}")]
        public async Task<ActionResult<bool>> RemoveEvent(int eventId)
        {
            var raceEvent = await _eventRepository.FindEventByIdAsync(eventId);
            return Ok(await _eventRepository.DeleteAsync(raceEvent));
        }
        [HttpGet("{eventId}")]
        public async Task<ActionResult<Events>> FindEventById(int eventId)
        {
            var raceEvent = await _eventRepository.FindEventByIdAsync(eventId);
            return Ok(raceEvent);

        }
        [HttpGet("all")]
        public async Task<ActionResult<ICollection<Events>>> GetAllEvents()
        {
            var events = await  _eventRepository.GetAllAsync();
            return Ok(events);
        }

        [HttpPost("changeCar")]
        public async Task<ActionResult<bool>> ChangeCar(CarChangeRequest carChangeRequest)
        {
            var eventParticipant= await _eventParticipantsRepository.FindEventParticipantsByEventIdAndUserId(carChangeRequest.EventId, carChangeRequest.UserId);
            if (eventParticipant==null)
            {
                return BadRequest("Cannot change car for null Id");
            }
            eventParticipant.Car= carChangeRequest.Car;
            var response = await _eventParticipantsRepository.UpdateAsync(eventParticipant);
            return Ok(response);
        }

    }
}