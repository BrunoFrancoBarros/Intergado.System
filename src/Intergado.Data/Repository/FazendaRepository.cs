using Intergado.Business.Model;
using Intergado.Business.Repository;
using Intergado.Data.Context;

namespace Intergado.Data.Repository
{
    public class FazendaRepository : RepositoryBase<FazendaEntity>, IFazendaRepository
    {
        public FazendaRepository(IntergadoContext context) : base(context)
        {
        }
    }
}