using LIBs.Domain;
using LIBs.Domain.Enum;

namespace LIBs.Utils
{
    public class StatusVenda : IStatusVenda
    {
        public IStatusVenda proximoStatusVenda { get ; set; }

        public bool VerificaStatusVenda(Venda vendaAPersistir, EnumStatusVenda statusVendaDb)
        {
            IStatusVenda ConfirmacaoPagamento = new ConfirmacaoPagamento();
            IStatusVenda PagamentoAprovado = new PagamentoAprovado();
            IStatusVenda EmTransporte = new EmTransporte();
            IStatusVenda SemAlteracao = new SemAlteracao();

            ConfirmacaoPagamento.proximoStatusVenda = PagamentoAprovado;
            PagamentoAprovado.proximoStatusVenda = EmTransporte;
            EmTransporte.proximoStatusVenda = SemAlteracao;


            return ConfirmacaoPagamento.VerificaStatusVenda(vendaAPersistir,statusVendaDb);
        }
    }
}
