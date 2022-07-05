using DixRacing.Domain.Users.Commands;
using DixRacing.Domain.Users.Commands.Register;
using MediatR;

namespace API.Features.Users.RegisterUser
{
    public record RegisterUserCommand(RegisterUserDto registerUserDto) : IRequest<RegisterUserResponse>;
}
