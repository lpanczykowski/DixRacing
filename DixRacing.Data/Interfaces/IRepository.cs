using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<bool> SaveAsync();
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}