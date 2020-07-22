using FluentValidation;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Interface;
using Puc.Minas.Banking.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puc.Minas.Banking.Service.Validation
{
    public class CorrentistaValidation : AbstractValidator<Correntista>
    {
        public CorrentistaValidation()
        {
            RuleFor(o => o.Cpf)
                .Matches(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$")
                .WithMessage("O CPF está em um formato inválido!")
                .WithErrorCode("001");

            RuleFor(o => o.Telefone)
                .Matches(@"^([0-9]{2}|\([0-9]{2}\))-([0-9]{4}|[0-9]{5})-[0-9]{4}$")
                .WithMessage("O telefone está em um formato inválido!")
                .WithErrorCode("002");
        }
    }
}
