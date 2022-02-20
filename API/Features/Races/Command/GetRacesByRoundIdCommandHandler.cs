using AutoMapper;
using DixRacing.Domain.Races;
using DixRacing.Domain.SharedKernel;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Races.Command
{
    public class GetRacesByRoundIdCommandHandler : IRequestHandler<GetRacesByRoundIdCommand, IEnumerable<GetRacesByRoundIdResponse>>
    {
        private readonly IRepository<Race, int> _repository;
        private readonly IMapper _mapper;

        public GetRacesByRoundIdCommandHandler(IRepository<Race,int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetRacesByRoundIdResponse>> Handle(GetRacesByRoundIdCommand request, CancellationToken cancellationToken)
        {
            var races = await _repository.GetByPropertyAsync(x=>x.RoundId == request.RoundId);
            var response = _mapper.Map<IEnumerable<Race>,IEnumerable<GetRacesByRoundIdResponse>>(races);
            return response;
        }
    }
}