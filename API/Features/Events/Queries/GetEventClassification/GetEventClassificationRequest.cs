using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Events.Queries.GetEventClassification
{
    public record GetEventClassificationRequest(int EventId) : IRequest<GetEventClassificationResponse>
    {
        
    }
}