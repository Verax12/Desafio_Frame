using LIBs.Domain.Base;
using LIBs.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LIBs.Domain
{
    public class Venda : BaseModel
    {
        public List<Veiculo> Veiculos { get; set; }
        public EnumStatusVenda StatusVenda { get;set;}
        public Guid VendedorCodigo { get; set; }
        [Required]
        public Vendedor Vendedor { get; set; }
    }
}
