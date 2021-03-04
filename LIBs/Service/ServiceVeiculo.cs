using LIBs.Domain;
using LIBs.Repository.IRepositoy;

namespace LIBs.Service
{
    public class ServiceVeiculo : ServicesBase<Veiculo>, IServiceVeiculo
    {
        private readonly IRepositoryVeiculo _repositoryVeiculo;
        public ServiceVeiculo(IRepositoryVeiculo repositoryVeiculo) : base(repositoryVeiculo)
        {
            _repositoryVeiculo = repositoryVeiculo;
        }
    }
}
