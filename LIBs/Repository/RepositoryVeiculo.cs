using LIBs.Domain;
using LIBs.Infra.Context;
using LIBs.Repository.IRepositoy;

namespace LIBs.Repository
{
    public class RepositoryVeiculo : RepositoryBase<Veiculo>, IRepositoryVeiculo
    {
        private readonly ProjetoContext _context;
        public RepositoryVeiculo(ProjetoContext context) : base(context)
        {
            _context = context;

        }
    }
}
