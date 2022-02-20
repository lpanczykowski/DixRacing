using DixRacing.Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DixRacing.DataAccess
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        private readonly DixRacingDbContext _dbContext;

        public Repository(DixRacingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await _dbContext.Set<TEntity>().SingleOrDefaultAsync(x => x.Id!.Equals(id));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TId> CreateAsync(TEntity entity)
        {
            var entityEntry = await _dbContext.Set<TEntity>().AddAsync(entity);

            return entityEntry.Entity.Id;
        }

        public Task<TId> DeleteAsync(TId id)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetUniqueByPropertyAsync(Expression<Func<TEntity, bool>> propertyExpression)
        {
            return await _dbContext.Set<TEntity>().Where(propertyExpression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetByPropertyAsync(Expression<Func<TEntity, bool>> propertyExpression)
        {
            return await _dbContext.Set<TEntity>().Where(propertyExpression).ToListAsync();
        }

        public TId Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return entity.Id;
        }
        public TId DeleteEntity(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return entity.Id;
        }
    }
}