using LIBs.Domain;
using LIBs.Repository.IRepositoy;
using LIBs.Service.IService;

namespace LIBs.Service
{
    public class ServiceVendedor   :ServicesBase<Vendedor>, IServiceVendedor
    {
        private readonly IRepositoryVendedor _repositoryVendedor;
        public ServiceVendedor(IRepositoryVendedor repositoryVendedor) : base(repositoryVendedor)
        {
            _repositoryVendedor = repositoryVendedor;
        }
    }
}