using DixRacing.Core.Models.Request;
using DixRacing.Data;
using DixRacing.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Services
{
    public class ResignFromEvent : IResignFromEvent
    {
        private readonly DataContext _datacontext;

        public ResignFromEvent(DataContext datacontext)
        {
            _datacontext = datacontext;
        }
        public async Task<bool> ResignFromEventAsync(ResignFromEventRequest resignFromEventRequest)
        {
            var participantion = await _datacontext.EventParticipants.Where(x => x.UserId == resignFromEventRequest.UserId
                                                                        && x.EventId == resignFromEventRequest.EventId).FirstOrDefaultAsync();
            _datacontext.Remove(participantion);
            return await _datacontext.SaveChangesAsync() > 0;

        }
    }
}