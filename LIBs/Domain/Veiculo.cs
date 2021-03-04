using LIBs.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIBs.Domain
{
   public  class Veiculo :BaseModel 
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string AnoFabricacao { get; set; }

    }
}
