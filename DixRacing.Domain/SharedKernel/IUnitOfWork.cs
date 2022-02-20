using System;
using System.Threading.Tasks;

namespace DixRacing.Domain.SharedKernel
{
    public interface IUnitOfWork
    {
        Task ExecuteInTransactionAsync(Func<Task> action);
    }
}
