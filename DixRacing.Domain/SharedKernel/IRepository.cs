using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DixRacing.Domain.SharedKernel
{
    public interface IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        Task<TEntity?> GetByIdAsync(TId id);

        Task<TEntity> GetUniqueByPropertyAsync(Expression<Func<TEntity, bool>> propertyExpression);

        Task<IEnumerable<TEntity>> GetByPropertyAsync(Expression<Func<TEntity, bool>> propertyExpression);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TId> CreateAsync(TEntity entity);

        Task<TId> DeleteAsync(TId id);

        TId Update(TEntity entity);
        TId DeleteEntity(TEntity entity);
    }
}
