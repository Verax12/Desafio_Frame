using System;
using System.Collections.Generic;
using System.Text;
using LIBs.Domain;
using LIBs.Domain.Enum;

namespace LIBs.Utils
{
    public class SemAlteracao : IStatusVenda
    {
        public IStatusVenda proximoStatusVenda { get; set ; }

        public bool VerificaStatusVenda(Venda vendaAPersistir, EnumStatusVenda statusVendaDb)
        {
            return false;
        }
    }
}
