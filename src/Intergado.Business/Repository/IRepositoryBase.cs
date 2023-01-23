using Intergado.Business.Model;

namespace Intergado.Business.Repository
{
    public interface IRepositoryBase<TEntity> : IDisposable
                        where TEntity : EntityBase
    {
        Task Add(TEntity entity);

        Task<TEntity> GetById(long id);

        Task<List<TEntity>> GetAll();

        Task Update(TEntity entity);

        Task Delete(long id);

        Task<int> SaveChanges();
    }
}