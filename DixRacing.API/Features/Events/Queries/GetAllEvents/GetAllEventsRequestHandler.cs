using AutoMapper;
using DixRacing.Domain.Events.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Events.Queries.GetAllEvents
{
    public class GetAllEventsRequestHandler : IRequestHandler<GetAllEventsRequest, GetAllEventsResponse>
    {
        private readonly IGetAllEventsQuery _query;
        private readonly IMapper _mapper;

        public GetAllEventsRequestHandler(IGetAllEventsQuery query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<GetAllEventsResponse> Handle(GetAllEventsRequest request, CancellationToken cancellationToken)
        {
            var response = _mapper.Map<IEnumerable<EventCaptionReadModel>, IEnumerable<EventDto>>(await _query.ExecuteAsync());

            return new GetAllEventsResponse(response);
        }
    }
}
