using System;
using System.Collections.Generic;

namespace DixRacing.Domain.Events.Commands.CreateEvent;

public record CreateEventDto(string Name,int GameId,byte[] Photo, IEnumerable<CreateRoundDto> Rounds);

public record CreateRoundDto(string ServerName, string ServerPassword, int TrackId, DateTime RoundDay, IEnumerable<CreateRaceDto> Races);

public record CreateRaceDto(DateTime PraticeDate, int PraticeLength, DateTime QualiDate, int QualiLength,
    DateTime RaceDate, int RaceLength, DateTime SigningTime);