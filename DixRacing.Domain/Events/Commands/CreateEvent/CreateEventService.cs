using DixRacing.Domain.Races;
using DixRacing.Domain.Rounds;
using DixRacing.Domain.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DixRacing.Domain.Events.Commands.CreateEvent;

public interface ICreateEventService
{
}

public class CreateEventService : ICreateEventService
{
    private readonly IRepository<Event> _eventRepository;
    private readonly IRepository<Round> _roundRepository;
    private readonly IRepository<Race> _raceRepository;

    public CreateEventService(IRepository<Event> eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<int> CreateEvent(CreateEventDto createEventDto)
    {
        var gameEvent = new Event()
        {
            Name = createEventDto.Name,
            Photo = createEventDto.Photo,
            GameId = createEventDto.GameId,
            Rounds = new List<Round>()
        };
        foreach (var round in createEventDto.Rounds )
        {
            var eventRound = new Round()
            {
                TrackId = round.TrackId,
                RoundDay = round.RoundDay,
                ServerName = round.ServerName,
                ServerPassword = round.ServerPassword,
                Races = new List<Race>()
            };
            foreach (var race in round.Races)
            {
                var roundRace = new Race()
                {
                    PracticeDate = race.PraticeDate,
                    PracticeLength = race.PraticeLength,
                    QualiDate = race.QualiDate,
                    QualiLength = race.QualiLength,
                    RaceLength = race.RaceLength,
                    RaceDate = race.RaceDate,
                    SigningTime = race.SigningTime
                };
                eventRound.Races.Add(roundRace);
            }
            gameEvent.Rounds.Add(eventRound);
        }
        return await _eventRepository.CreateAsync(gameEvent);
    }
}

