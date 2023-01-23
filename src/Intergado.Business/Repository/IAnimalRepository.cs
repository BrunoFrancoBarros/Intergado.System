using Intergado.Business.Model;

namespace Intergado.Business.Repository
{
    public interface IAnimalRepository : IRepositoryBase<AnimalEntity>
    {
        Task<List<AnimalEntity>> GetAnimaisFazendas();

        Task<AnimalEntity> GetAnimalFazenda(long id);

        Task<bool> GetIdentifierExists(string identificador);
    }
}