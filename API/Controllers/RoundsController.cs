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

        public RoundsController(IRoundsRepository roundsRepository)
        {
            _roundsRepository = roundsRepository;
        }

        [HttpPut("add")]
        public async Task<Rounds> AddRound(AddRoundRequest addRoundRequest)
        {
            var Round = new Rounds()
            {
                TrackId = addRoundRequest.TrackID,
                ServerPassword = addRoundRequest.ServerPassword,
                ServerName = addRoundRequest.ServerName
            };
            var response = await _roundsRepository.AddAsync(Round);
            return response;
        }
    }
}