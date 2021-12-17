using DixRacing.Core;
using DixRacing.Core.Models.Request;
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
    public class RaceController : BaseApiController
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IRaceConfirmation _raceConfirmation;

        public RaceController(IRaceRepository raceRepository, IRaceConfirmation raceConfirmation)
        {
            _raceConfirmation = raceConfirmation;
            _raceRepository = raceRepository;
        }
        [HttpPut("add")]
        public async Task<Races> AddRace(AddRaceRequest addRaceRequest)
        {
            var race = new Races()
            {
                EventId = addRaceRequest.EventId,
                MaxPlayers = addRaceRequest.MaxPlayers,
                SigningTime = addRaceRequest.SigningTime,
                StartingTime = addRaceRequest.StartingTime,
                TrackId = addRaceRequest.TrackId
            };
            var response = await _raceRepository.AddAsync(race);
            return response;
        }
        [HttpDelete("delete/{raceId}")]
        public async Task<ActionResult<bool>> DeleteRace(int raceId)
        {
            var race = await _raceRepository.FindRaceByIdAsync(raceId);
            var response = await _raceRepository.DeleteAsync(race);
            return Ok(response);
        }
        [HttpGet("{raceId}")]
        public async Task<ActionResult<Races>> FindRaceById(int raceId)
        {
            var race = await _raceRepository.FindRaceByIdAsync(raceId);
            return Ok(race);

        }

        [HttpPost("raceStatus")]
        public async Task<ActionResult<bool>> RaceStatus(RaceStatusRequest raceConfirmationRequest)
        {
            var response = await _raceConfirmation.ChangeRaceStatusAsync(raceConfirmationRequest);
            return Ok(response);
        }

    }

}