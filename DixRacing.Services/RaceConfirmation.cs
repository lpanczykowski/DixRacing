using DixRacing.Core.Models.Request;
using DixRacing.Data;
using DixRacing.Data.Entites;
using DixRacing.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Services
{
    public class RaceConfirmation : IRaceConfirmation
    {
        private readonly DataContext _dataContext;

        public RaceConfirmation(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> ChangeRaceStatusAsync(RaceStatusRequest raceStatusRequest)
        {
            var user = await _dataContext.RaceConfirmations.Where(x => x.UserId == raceStatusRequest.UserId && x.RaceId == raceStatusRequest.RaceId)
                                         .FirstOrDefaultAsync();
            if (user == null)
            {
                var userConfirmation = new RaceConfirmations()
                {
                    UserId = raceStatusRequest.UserId,
                    RaceId = raceStatusRequest.RaceId,
                    Confrimed = 1
                };
                _dataContext.Add(userConfirmation);
            }
            else
            {
                user.Confrimed = user.Confrimed > 0 ? 0 : 1;
                _dataContext.Update(user);
            }
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}