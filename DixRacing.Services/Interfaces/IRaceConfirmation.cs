using DixRacing.Data.Models.Request;
using System.Threading.Tasks;

namespace DixRacing.Services.Interfaces
{
    public interface IRaceConfirmation
    {
        Task<bool> ChangeRaceStatusAsync(RaceStatusRequest raceStatusRequest);
    }
}