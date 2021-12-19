using DixRacing.Core.Models.Request;
using DixRacing.Core.Models.Response;
using DixRacing.Data;
using DixRacing.Data.Entites;
using DixRacing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Services
{
    public class AddEvent : IAddEvent
    {
        private readonly DataContext _datacontext;

        public AddEvent(DataContext datacontext)
        {
            _datacontext = datacontext;
        }
        public async Task<bool> AddEventAsync(AddEventRequest addEventRequest)
        {
            var events = new Events
            {
                GameId = addEventRequest.GameId,
                Name = addEventRequest.Name,

            };
            _datacontext.Add(events);
            return await _datacontext.SaveChangesAsync() > 0;


        }
    }
}