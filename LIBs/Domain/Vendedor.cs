
using LIBs.Domain.Base;
using System.Collections.Generic;

namespace LIBs.Domain
{
    public class Vendedor : BaseModel
    {
        public string Nome { get; set; }

        public string CPF { get; set; }
        public string Email { get; set; }

        public ICollection<Venda> Vendas { get; set; }
    }
}