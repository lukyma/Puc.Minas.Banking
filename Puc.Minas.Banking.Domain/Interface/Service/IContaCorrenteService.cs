using Puc.Minas.Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Puc.Minas.Banking.Domain.Interface
{
    public interface IContaCorrenteService : IService<ContaCorrente>
    {
        Movimentacao Depositar(decimal valor, int numeroConta, int digito);
        Movimentacao Debitar(decimal valor, int numeroConta, int digito);
    }
}
