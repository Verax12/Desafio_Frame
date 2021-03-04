using LIBs.Domain;
using LIBs.Domain.Enum;

namespace LIBs.Utils
{
    public class ConfirmacaoPagamento : IStatusVenda
    {
        public IStatusVenda proximoStatusVenda { get; set; }
        public bool VerificaStatusVenda(Venda vendaAPersistir, EnumStatusVenda statusVendaDb)
        {
            if (vendaAPersistir.StatusVenda.Equals(EnumStatusVenda.PagamentoAprovado) && statusVendaDb.Equals(EnumStatusVenda.ConfirmacaoPagamento))
            {
                return true;
            }

            if (vendaAPersistir.StatusVenda.Equals(EnumStatusVenda.Cancelada) && statusVendaDb.Equals(EnumStatusVenda.ConfirmacaoPagamento))
            {
                return true;
            }

            return proximoStatusVenda.VerificaStatusVenda(vendaAPersistir, statusVendaDb);
        }
    }
}
