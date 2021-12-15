using DixRacing.Core;
using DixRacing.Core.Models.Request;
using DixRacing.Core.Models.Response;
using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using DixRacing.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class EventController : BaseApiController
    {
        private readonly ISignForEvent _signForEvent;
        private readonly IResignFromEvent _resignFromEvent;
        private readonly IEventRepository _eventRepository;

        public EventController(ISignForEvent signForEvent,
                               IResignFromEvent resignFromEvent,
                               IEventRepository eventRepository
                            )
        {
            _signForEvent = signForEvent;
            _resignFromEvent = resignFromEvent;
            _eventRepository = eventRepository;
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
            return (raceEvent);

        }

    }
}