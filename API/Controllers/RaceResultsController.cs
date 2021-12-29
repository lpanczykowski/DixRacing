using DixRacing.Core;
using DixRacing.Core.Models.Request;
using DixRacing.Core.Models.Response;
using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using DixRacing.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class RaceResultsController : BaseApiController
    
    {
        private readonly IRaceResultsRepository _raceResultsRepository;
        private readonly IRaceResultsService _raceResultService;

        public RaceResultsController(IRaceResultsService raceResultService )
        {
            
            _raceResultService = raceResultService;
        }
        [HttpGet("{raceId}")]
        public async Task<ICollection<RaceResultsResponse>> GetRaceResultsByRaceId(int raceId)
        {
            var response = await _raceResultService.FindRaceResultsByRaceId(raceId);
            return response;
        }
        [HttpPost("addPenaltyPoints")]
        public async Task<bool> AddPenaltyPoints(AddPenaltyPointsRequest addPenaltyPointsRequest)
        {
            return true
            ;
        }

    }
}