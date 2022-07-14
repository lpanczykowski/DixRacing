using DixRacing.Domain.SharedKernel;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace DixRacing.Domain.Events.Commands;

public interface IUpdateEventService
{
    public Task UpdateEventAsync(EventDto eventDto);
}
public class UpdateEventService : IUpdateEventService
{
    private readonly IRepository<Event> _eventRepository;

    public UpdateEventService(IRepository<Event> eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task UpdateEventAsync(EventDto eventDto)
    {
        var eventRace = await _eventRepository.GetByIdAsync(eventDto.EventId);
        if (eventRace is null)
        {
            throw new InvalidOperationException("Nie ma takiego eventu");
        }

        UpdateName(eventRace,eventDto);
        UpdateRules(eventRace,eventDto);
        UpdatePhoto(eventRace, eventDto);
    }

    private void UpdatePhoto(Event eventRace, EventDto eventDto)
    {
        if (eventDto.Photo is not null)
        {
            eventRace.Photo = eventDto.Photo;
        }
    }

    private void UpdateRules(Event eventRace, EventDto eventDto)
    {
        if (eventDto.Rules is not null)
        {
            eventRace.Rules = eventDto.Rules;
        }
    }

    private void UpdateName(Event eventRace, EventDto eventDto)
    {
        if (eventDto.Name is not null)
        {
            eventRace.Name = eventDto.Name;
        }
    }
}