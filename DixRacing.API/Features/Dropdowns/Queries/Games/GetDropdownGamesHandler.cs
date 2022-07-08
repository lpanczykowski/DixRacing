using AutoMapper;
using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Utility;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Dropdowns.Queries.Games
{
    public class GetDropdownGamesHandler : IRequestHandler<GetDropdownGamesRequest, GetDropdownResponse>
    {
        private readonly IRepository<Game> _gameRepository;
        private readonly IMapper _mapper;

        public GetDropdownGamesHandler(IRepository<Game> gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<GetDropdownResponse> Handle(GetDropdownGamesRequest request, CancellationToken cancellationToken)
        {
            var games = await _gameRepository.GetAllAsync();
            var result = _mapper.Map<List<Game>,List<DropdownDto>>(games.ToList());
            return new GetDropdownResponse(result);
        }
    }
}