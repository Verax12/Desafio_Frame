using LIBs.Domain;
using LIBs.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIBs.Utils
{
    public interface IStatusVenda
    {
        bool VerificaStatusVenda(Venda venda, EnumStatusVenda statusVendaDb);
        IStatusVenda proximoStatusVenda { get; set; }
    }
}
