using LIBs.Domain;
using LIBs.Infra.Context;
using LIBs.Repository.IRepositoy;

namespace LIBs.Repository
{
    public class RepositoryVendedor : RepositoryBase<Vendedor>, IRepositoryVendedor
    {
        private readonly ProjetoContext _context;
        public RepositoryVendedor(ProjetoContext context) : base(context)
        {
            _context = context;

        }
    }
}

