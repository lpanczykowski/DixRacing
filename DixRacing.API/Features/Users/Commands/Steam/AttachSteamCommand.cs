using MediatR;

namespace API.Features.Users.Commands.Steam
{
    public record AttachSteamCommand(int userId,string steamId) : IRequest<bool>
    {
    
    }
}