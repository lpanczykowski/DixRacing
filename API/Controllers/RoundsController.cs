using AutoMapper;
using DixRacing.Core;
using DixRacing.Core.Models.Request;
using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class RoundsController : BaseApiController
    {
        private readonly IRoundsRepository _roundsRepository;
        private readonly IMapper _mapper;

        public RoundsController(IRoundsRepository roundsRepository, IMapper mapper)
        {
            _roundsRepository = roundsRepository;
            _mapper = mapper;
        }

        [HttpPut("add")]
        public async Task<Rounds> AddRound(AddRoundRequest addRoundRequest)
        {
            var Round = _mapper.Map<AddRoundRequest, Rounds>(addRoundRequest);
            var response = await _roundsRepository.AddAsync(Round);
            return response;
        }
    }
}