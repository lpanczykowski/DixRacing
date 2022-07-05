//using DixRacing.Data.Interfaces;
//using DixRacing.Data.Models.Request;
//using DixRacing.Data.Models.Response;
//using DixRacing.Services.Interfaces;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace DixRacing.API.Controllers
//{
//    [Authorize]
//    public class RaceResultsController : BaseApiController

//    {
//        private readonly IRaceResultsRepository _raceResultsRepository;
//        private readonly IRaceResultsService _raceResultService;

//        public RaceResultsController(IRaceResultsService raceResultService, IRaceResultsRepository raceResultsRepository)
//        {

//            _raceResultService = raceResultService;
//            _raceResultsRepository = raceResultsRepository;
//        }
//        [HttpGet("{raceId}")]
//        public async Task<ICollection<RaceResultsResponse>> GetRaceResultsByRaceId(int raceId)
//        {
//            var response = await _raceResultService.FindRaceResultsByRaceId(raceId);
//            return response;
//        }
//        [HttpPost("addPenalty")]
//        public async Task<ActionResult<int>> AddPenaltyPoints(AddPenaltyPointsRequest addPenaltyPointsRequest)
//        {
//            var raceResult = await _raceResultsRepository.FindRaceResultByUserIdAndRaceIdAsync(addPenaltyPointsRequest.UserId, addPenaltyPointsRequest.RaceId);
//            if (raceResult == null)
//            {
//                return BadRequest("Cannot assign penalty points to null");
//            }
//            raceResult.PenaltyPoints += addPenaltyPointsRequest.PenaltyPoints;
//            await _raceResultsRepository.UpdateAsync(raceResult);
//            return raceResult.PenaltyPoints;
//        }
//    }
//}