using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Races.Command.GetRaceById
{
    public record GetRaceByIdCommand(int Id) : IRequest<GetRaceByIdResponse>
    {
        
    }
    public record GetRaceByIdResponse(int Id, string SessionType);
}