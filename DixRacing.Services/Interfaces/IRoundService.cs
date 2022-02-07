using DixRacing.Data.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Services.Interfaces
{
    public interface IRoundService
    {
        Task<ICollection<GetEventRoundsResponse>> GetEventRoundsResponsesByEventId(int eventId);
    }
}