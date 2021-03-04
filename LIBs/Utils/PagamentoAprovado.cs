using LIBs.Domain;
using LIBs.Domain.Enum;

namespace LIBs.Utils
{
    public class PagamentoAprovado : IStatusVenda
    {
        public IStatusVenda proximoStatusVenda { get; set; }
        public bool VerificaStatusVenda(Venda vendaAPersistir, EnumStatusVenda statusVendaDb)
        {
            if (vendaAPersistir.StatusVenda.Equals(EnumStatusVenda.EmTransporte)&& statusVendaDb.Equals(EnumStatusVenda.PagamentoAprovado))
            {
                return true;
            }

            if (vendaAPersistir.StatusVenda.Equals(EnumStatusVenda.Cancelada) && statusVendaDb.Equals(EnumStatusVenda.PagamentoAprovado))
            {
                return true;
            }
            return proximoStatusVenda.VerificaStatusVenda(vendaAPersistir, statusVendaDb);
        }
    }
}
