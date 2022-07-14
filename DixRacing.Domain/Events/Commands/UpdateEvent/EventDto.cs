namespace DixRacing.Domain.Events.Commands;

public record EventDto(int EventId, string? Name, string? Rules, byte[]? Photo);
