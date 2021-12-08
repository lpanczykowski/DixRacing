using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DixRacing.Data.Interfaces;

namespace DixRacing.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _dataContext.Set<TEntity>();
            }
            catch (Exception ex)
            {

                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _dataContext.AddAsync(entity);
                await _dataContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _dataContext.Update(entity);
                await _dataContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
        public async Task<bool> SaveAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}