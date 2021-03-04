using LIBs.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIBs.Service.IService
{
    public interface IServiceVenda : IServiceBase<Venda>
    {
        bool ValidaStatusVenda(Venda vendaAPersistir);
    }
}
