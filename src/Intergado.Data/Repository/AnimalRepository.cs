using Intergado.Business.Model;
using Intergado.Business.Repository;
using Intergado.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Intergado.Data.Repository
{
    public class AnimalRepository : RepositoryBase<AnimalEntity>, IAnimalRepository
    {
        public AnimalRepository(IntergadoContext context) : base(context)
        {
        }

        public async Task<List<AnimalEntity>> GetAnimaisFazendas()
        {
            return await _context.Animais.AsNoTracking()
                                          .Include(f => f.Fazenda)
                                          .OrderBy(f => f.Fazenda.Descricao)
                                          .ToListAsync();
        }

        public async Task<AnimalEntity> GetAnimalFazenda(long id)
        {
            return await _context.Animais.AsNoTracking()
                                         .Include(f => f.Fazenda)
                                         .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> GetIdentifierExists(string identificador)
        {
            return await _context.Animais.AsNoTracking().AnyAsync(p => p.Identificador.Equals(identificador)); ;
        }
    }
}