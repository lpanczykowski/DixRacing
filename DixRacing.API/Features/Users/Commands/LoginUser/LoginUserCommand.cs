using DixRacing.Domain.Users.Commands.Login;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Features.Users.Commands.LoginUser
{
    public record LoginUserCommand(string SteamId) : IRequest<LoginUserResponse>;
}
