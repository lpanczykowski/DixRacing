using DixRacing.Data.Models.Request;
using System.Threading.Tasks;

namespace DixRacing.Services.Interfaces
{
    public interface IResignFromEvent
    {
        Task<bool> ResignFromEventAsync(ResignFromEventRequest resignFromEventRequest);
    }
}