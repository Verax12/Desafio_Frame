using LIBs.Domain;
using LIBs.Domain.Enum;
using LIBs.Repository.IRepositoy;
using LIBs.Service.IService;
using LIBs.Utils;
using System;

namespace LIBs.Service
{
    public class ServiceVenda : ServicesBase<Venda>, IServiceVenda
    {
        private readonly IRepositoryVenda _repositoryVenda;
        private readonly IStatusVenda _statusVenda;
        public ServiceVenda(IRepositoryVenda repositoryVenda, IStatusVenda statusVenda) : base(repositoryVenda)
        {
            _repositoryVenda = repositoryVenda;
            _statusVenda = statusVenda;
        }

        public bool ValidaStatusVenda(Venda venda)
        {
            EnumStatusVenda statusVendaPersistida = _repositoryVenda.GetById(venda.Codigo).StatusVenda;            

            return _statusVenda.VerificaStatusVenda(venda, statusVendaPersistida);

            
        }

    }
}
