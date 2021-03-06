using MediatR;

namespace API.Features.Events.Commands.SignForEvent
{
    public record SignForEventCommand(int eventId,
                                      int userId,
                                      int Car,
                                      byte[] Livery,
                                      int Number,
                                      int Team) : IRequest<int>;
    
    
}