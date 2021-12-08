using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task<TEntity> AddAsync(TEntity entity);
        IEnumerable<TEntity> GetAll();
        Task<bool> SaveAsync();
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}