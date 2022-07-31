using AutoMapper;
using DixRacing.Domain.Tracks.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Dropdowns.Queries.Tracks;

public record GetDropdownTracksHandler : IRequestHandler<GetDropdownTracksRequest,GetDropdownResponse>
{
    private readonly IGetAllTracksQuery _query;
    private readonly IMapper _mapper;

    public GetDropdownTracksHandler(IGetAllTracksQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<GetDropdownResponse> Handle(GetDropdownTracksRequest request, CancellationToken cancellationToken)
    {
        var result = await _query.ExecuteAsync(request.GameId);
        var dropdownValue = _mapper.Map<IEnumerable<TrackReadModel>, IEnumerable<DropdownDto>>(result);
        return new GetDropdownResponse(dropdownValue);
    }
}