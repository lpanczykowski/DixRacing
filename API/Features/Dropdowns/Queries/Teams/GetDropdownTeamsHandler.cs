using AutoMapper;
using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Teams;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Dropdowns.Queries.Teams
{
    public class GetDropdownTeamsHandler : IRequestHandler<GetDropdownTeamsRequest, GetDropdownResponse>
    {
        private readonly IRepository<Team> _teamRepository;
        private readonly IMapper _mapper;

        public GetDropdownTeamsHandler(IRepository<Team> teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<GetDropdownResponse> Handle(GetDropdownTeamsRequest request, CancellationToken cancellationToken)
        {
            var teams= await _teamRepository.GetByPropertyAsync(x=>x.EventId==request.EventId);
            var result= _mapper.Map<List<Team>,List<DropdownDto>>(teams.ToList());
            return new GetDropdownResponse(result);
        }
    }
}