using DixRacing.Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DixRacing.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DixRacingDbContext _dbContext;

        public Repository(DixRacingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().SingleOrDefaultAsync(x => x.Id!.Equals(id));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<int> CreateAsync(TEntity entity)
        {
            var entityEntry = await _dbContext.Set<TEntity>().AddAsync(entity);

            return entityEntry.Entity.Id;
        }
        public async Task CreateMultipleAsync(List<TEntity> entities) 
            => await _dbContext.Set<TEntity>().AddRangeAsync(entities);

        public Task<int> DeleteAsync(int id)
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

        public int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return entity.Id;
        }
        public int DeleteEntity(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return entity.Id;
        }
    }
}