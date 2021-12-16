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
    public class RaceController : BaseApiController
    {
        private readonly IRaceRepository _raceRepository;

        public RaceController(IRaceRepository raceRepository)
        {
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
        public async Task<bool> DeleteRace(int raceId)
        {
            var race = await _raceRepository.FindRaceByIdAsync(raceId);
            return await _raceRepository.DeleteAsync(race);
        }
        [HttpGet("{raceId}")]
        public async Task<Races> FindRaceById(int raceId)
        {
            var race = await _raceRepository.FindRaceByIdAsync(raceId);
            return race;

        }
        // [HttpPost("confirm")]        
        // [HttpPost("withdraw")]

    }

}