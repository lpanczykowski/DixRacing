using DixRacing.Data.Models.ResultModels;
using System.Threading.Tasks;

namespace DixRacing.Services.Interfaces
{
    public interface IResultManager
    {
        Task<int> ManageResults(Results results);
    }
}