using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.WebApi.Model
{
    public class ContaCorrenteVM
    {
        public int Numero { get; set; }
        public int Digito { get; set; }
        public decimal Saldo { get; set; }
        public CorrentistaVM Correntista { get; set; }
    }
}
