using FluentValidation;
using Puc.Minas.Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Puc.Minas.Banking.Service.Validation
{
    public class MovimentacaoValidation : AbstractValidator<Movimentacao>
    {
        public MovimentacaoValidation()
        {
            RuleFor(o => o)
                .Must(ValidarLimiteCredito)
                .WithErrorCode("005")
                .WithMessage("Você ultrapassou o limite de crédito!");
        }

        public bool ValidarLimiteCredito(Movimentacao movimentacao)
        {
            return !(movimentacao.Operacao == TipoOperacao.Debito
                   && (movimentacao.UltimoSaldo + (-1 * movimentacao.Valor)) < -2500);
        }
    }
}
