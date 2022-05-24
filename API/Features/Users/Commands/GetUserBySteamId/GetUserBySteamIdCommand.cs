using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Users.Commands.GetUserBySteamId
{
    public record GetUserBySteamIdCommand(string steamId) : IRequest<bool>
    {

    }
}