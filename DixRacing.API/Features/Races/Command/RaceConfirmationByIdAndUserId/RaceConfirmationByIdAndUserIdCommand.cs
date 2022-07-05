using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Races.Command.RaceConfirmationByIdAndUserId
{
    public record RaceConfirmationByIdAndUserIdCommand(int RaceId, int UserId) : IRequest<bool>
    {

    }
}