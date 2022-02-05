using DixRacing.Data;
using DixRacing.Data.Entites;
using DixRacing.Data.Models.Request;
using DixRacing.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Services
{
    public class SignForEvent : ISignForEvent
    {
        private readonly DataContext _dataContext;

        public SignForEvent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> SignUserForEventAsync(SignForEventRequest signForEventRequest)
        {
            var number = await _dataContext.EventParticipants.Where(x=>x.Number == signForEventRequest.Number).AnyAsync();
            if (number) throw new Exception ("Number already taken");
            var user = await _dataContext.EventParticipants.Where(x => x.UserId == signForEventRequest.UserId && x.EventId == x.UserId).AnyAsync();
            if (user) throw new Exception("User already signed for this event");            
            var participant = new EventParticipants
            {
                Car = signForEventRequest.Car,
                EventId = signForEventRequest.EventId,
                UserId = signForEventRequest.UserId,
                Livery = signForEventRequest.Livery,
                Number = signForEventRequest.Number
            };
            _dataContext.Add(participant);
            return await _dataContext.SaveChangesAsync() > 0;

        }
    }
}