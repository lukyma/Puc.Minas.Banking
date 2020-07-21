using Puc.Minas.Banking.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puc.Minas.Banking.Domain.Entity
{
    public class ContaCorrente : AggregateRoot
    {
        public ContaCorrente()
        {
            Movimentacoes = new HashSet<Movimentacao>();
        }
        public int IdCorrentista { get; set; }
        public int Numero { get; set; }
        public int Digito { get; set; }
        public decimal Saldo
        {
            get 
            {
                Movimentacao movimentacao = Movimentacoes
                       .OrderByDescending(o => o.DataMovimentacao)
                       .FirstOrDefault();
                return movimentacao == null ? 0 : (movimentacao.Operacao == TipoOperacao.Credito ?
                                                   (movimentacao.UltimoSaldo + movimentacao.Valor) : 
                                                   (movimentacao.UltimoSaldo + (-1 * movimentacao.Valor)));
            }
        }
        public decimal LimiteCredito { get; set; }
        public virtual Correntista Correntista { get; set; }
        public virtual ICollection<Movimentacao> Movimentacoes { get; set; }

        public void ValidarLimiteCredito(decimal saldoPosterior)
        {
            if((LimiteCredito * (-1)) > saldoPosterior)
            {
                throw new RuleException("Você excedeu o limite de crédito.", "001");
            }
        }
    }
}
