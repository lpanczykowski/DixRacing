using DixRacing.Domain.SharedKernel;
using System;
using System.Threading.Tasks;

namespace DixRacing.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DixRacingDbContext _dbContext;

        public UnitOfWork(DixRacingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ExecuteInTransactionAsync(Func<Task> action)
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                await action();
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
