using AutoMapper;
using DixRacing.Domain.Events;
using DixRacing.Domain.Events.Queries;
using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Utility;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Dropdowns.Queries.Cars
{
    public class GetDropdownCarsHandler : IRequestHandler<GetDropdownCarsRequest, GetDropdownResponse>
    {
        private readonly IGetEventCarsByEventIdQuery _query;
        private readonly IMapper _mapper;
        public GetDropdownCarsHandler(IGetEventCarsByEventIdQuery query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<GetDropdownResponse> Handle(GetDropdownCarsRequest request, CancellationToken cancellationToken)
        {
            var cars = await _query.ExecuteAsync(request.eventId);
            var result =  _mapper.Map<IEnumerable<EventCarReadModel>,IEnumerable<DropdownDto>>(cars);
            return new GetDropdownResponse(result);
        }
    }
}