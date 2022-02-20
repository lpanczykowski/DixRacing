using AutoMapper;
using DixRacing.Data.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class RoundsController : BaseApiController
    {
        private readonly IRoundsRepository _roundsRepository;
        private readonly IMapper _mapper;
        private readonly IRoundService _roundService;

        public RoundsController(IRoundsRepository roundsRepository,
                                IMapper mapper,
                                IRoundService roundService)
        {
            _roundsRepository = roundsRepository;
            _mapper = mapper;
            _roundService = roundService;
        }
        [HttpGet("{roundId}/races")]
        public Task<ActionResult<GetRoundWithRacesResponse>> GetRoundWithRaces(int roundId) 
            => SendAsync(new GetRoundWithRacesRequest(roundId));

        [HttpPut("add")]
        public async Task<Rounds> AddRound(AddRoundRequest addRoundRequest)
        {
            var Round = _mapper.Map<AddRoundRequest, Rounds>(addRoundRequest);
            var response = await _roundsRepository.AddAsync(Round);
            return response;
        }

        [HttpGet("{roundId}/races")]

        public async Task<ICollection<GetRacesByRoundIdResponse>> GetRacesByRoundId (int roundId)
        {
            var response= await _roundService.GetRacesByRoundId(roundId);
            return response;
        }
    }
}