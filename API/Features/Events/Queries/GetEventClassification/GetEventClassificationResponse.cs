using DixRacing.Domain.Events.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Events.Queries.GetEventClassification
{
    public record GetEventClassificationResponse(ICollection<EventClassificationReadModel> EventClassifications);
}