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

        public RaceResultsController(IRaceResultsService raceResultService,IRaceResultsRepository  raceResultsRepository )
        {
            
            _raceResultService = raceResultService;
            _raceResultsRepository = raceResultsRepository;
        }
        [HttpGet("{raceId}")]
        public async Task<ICollection<RaceResultsResponse>> GetRaceResultsByRaceId(int raceId)
        {
            var response = await _raceResultService.FindRaceResultsByRaceId(raceId);
            return response;
        }
        [HttpPost("addPenalty")]
        public async Task<ActionResult<int>> AddPenaltyPoints(AddPenaltyPointsRequest addPenaltyPointsRequest)
        {
            var raceResult= await _raceResultsRepository.FindRaceResultByUserIdAndRaceIdAsync(addPenaltyPointsRequest.UserId,addPenaltyPointsRequest.RaceId);
            if (raceResult==null)
            {
                return BadRequest("Cannot assign penalty points to null");
            }
            raceResult.PenaltyPoints+=addPenaltyPointsRequest.PenaltyPoints;
            await _raceResultsRepository.UpdateAsync(raceResult);
            return raceResult.PenaltyPoints;
        }
        }
}