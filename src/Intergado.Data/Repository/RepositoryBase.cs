using Intergado.Business.Model;
using Intergado.Business.Repository;
using Intergado.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Intergado.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
                    where TEntity : EntityBase, new()
    {
        protected readonly IntergadoContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(IntergadoContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task Add(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(long id)
        {
            _dbSet.Remove(new TEntity() { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}