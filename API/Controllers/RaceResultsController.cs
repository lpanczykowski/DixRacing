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
    public class RaceResultsController : BaseApiController

    {
        private readonly IRaceResultsRepository _raceResultsRepository;

        public RaceResultsController(IRaceResultsRepository raceResultsRepository)
        {
            _raceResultsRepository = raceResultsRepository;
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