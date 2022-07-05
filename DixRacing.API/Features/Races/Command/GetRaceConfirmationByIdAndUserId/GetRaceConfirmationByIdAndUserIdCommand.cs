using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Races.Command.GetRaceConfirmationByIdAndUserId
{
    public record GetRaceConfirmationByIdAndUserIdCommand(int RaceId, int UserId) : IRequest<bool>
    {

    }
}