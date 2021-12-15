using DixRacing.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Services.Interfaces
{
    public interface IAddEvent
    {
        Task<bool> AddEventAsync(AddEventRequest addEventRequest);
    }
}