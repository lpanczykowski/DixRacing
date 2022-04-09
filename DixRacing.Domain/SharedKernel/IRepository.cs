using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DixRacing.Domain.SharedKernel
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(int id);

        Task<TEntity> GetUniqueByPropertyAsync(Expression<Func<TEntity, bool>> propertyExpression);

        Task<IEnumerable<TEntity>> GetByPropertyAsync(Expression<Func<TEntity, bool>> propertyExpression);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<int> CreateAsync(TEntity entity);
        Task CreateMultipleAsync(List<TEntity> entities);

        Task<int> DeleteAsync(int id);

        int Update(TEntity entity);
        int DeleteEntity(TEntity entity);
    }
}
