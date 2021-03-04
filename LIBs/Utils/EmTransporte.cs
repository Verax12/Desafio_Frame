using LIBs.Domain;
using LIBs.Domain.Enum;

namespace LIBs.Utils
{
    public class EmTransporte : IStatusVenda
    {
        public IStatusVenda proximoStatusVenda { get ; set ; }

        public bool VerificaStatusVenda(Venda vendaAPersistir, EnumStatusVenda statusVendaDb)
        {
            if (vendaAPersistir.StatusVenda.Equals(EnumStatusVenda.Entregue) && statusVendaDb.Equals(EnumStatusVenda.EmTransporte))
            {
                return true;
            }
            return proximoStatusVenda.VerificaStatusVenda(vendaAPersistir, statusVendaDb);
        }
    }
}
