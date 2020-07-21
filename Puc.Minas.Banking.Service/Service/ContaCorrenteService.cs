using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Interface;
using Puc.Minas.Banking.Domain.Interface.Core;
using Puc.Minas.Banking.Domain.Interface.Repository;
using Puc.Minas.Banking.Service.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puc.Minas.Banking.Service.Service
{
    public class ContaCorrenteService : Service<ContaCorrente>, IContaCorrenteService
    {
        public ContaCorrenteService(IContaCorrenteRepository repository) : base(repository)
        {

        }

        public ContaCorrente CreditarValorConta(decimal valor, int numeroConta, int digito)
        {
            ContaCorrente contaCorrente = GetAll().FirstOrDefault(o => o.Numero == numeroConta && 
                                                                       o.Digito == digito);
            contaCorrente.Movimentacoes.Add(new Movimentacao()
            {
                Valor = valor,
                Operacao = TipoOperacao.Credito
            });

            Update(contaCorrente);

            return contaCorrente;
        }

        public ContaCorrente DebitarValorConta(decimal valor, int numeroConta, int digito)
        {
            ContaCorrente contaCorrente = GetAll().FirstOrDefault(o => o.Numero == numeroConta &&
                                                                       o.Digito == digito);
            contaCorrente.Movimentacoes.Add(new Movimentacao()
            {
                Valor = valor,
                Operacao = TipoOperacao.Debito
            });

            Update(contaCorrente);

            return contaCorrente;
        }
    }
}
