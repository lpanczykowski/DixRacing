using DixRacing.Data.Models.Request;
using System.Threading.Tasks;

namespace DixRacing.Services.Interfaces
{
    public interface ISignForEvent
    {
        Task<bool> SignUserForEventAsync(SignForEventRequest signForEventRequest);
    }
}