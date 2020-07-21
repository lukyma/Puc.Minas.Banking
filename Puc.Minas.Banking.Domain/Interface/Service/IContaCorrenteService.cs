﻿using Puc.Minas.Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Puc.Minas.Banking.Domain.Interface
{
    public interface IContaCorrenteService : IService<ContaCorrente>
    {
        ContaCorrente CreditarValorConta(decimal valor, int numeroConta, int digito);
        ContaCorrente DebitarValorConta(decimal valor, int numeroConta, int digito);
    }
}