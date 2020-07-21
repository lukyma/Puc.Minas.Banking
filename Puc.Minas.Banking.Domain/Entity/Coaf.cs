using System;
using System.Collections.Generic;
using System.Text;

namespace Puc.Minas.Banking.Domain.Entity
{
    public class Coaf : Entity
    {
        public int IdMovimentacao { get; set; }
        public virtual Movimentacao Movimentacao { get; set; }
    }
}
