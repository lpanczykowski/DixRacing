using DixRacing.Core.Models.Request;
using DixRacing.Core.Models.Response;
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
    public class SignForEvent : ISignForEvent
    {
        private readonly DataContext _datacontext;

        public SignForEvent(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task<bool> SignUserForEventAsync(SignForEventRequest signForEventRequest)
        {
            var check = await _datacontext.EventParticipants.Where(x => x.UserId == signForEventRequest.UserId && x.EventId == x.UserId).AnyAsync();
            if (check) throw new Exception("User already signed for this event");
            var participant = new EventParticipants
            {
                Car = signForEventRequest.Car,
                EventId = signForEventRequest.EventId,
                UserId = signForEventRequest.UserId,
                Livery = signForEventRequest.Livery,
                Number = signForEventRequest.Number
            };
            _datacontext.Add(participant);
            return await _datacontext.SaveChangesAsync() > 0;

        }
    }
}