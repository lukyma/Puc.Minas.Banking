using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Puc.Minas.Banking.Domain.Entity
{
    public class Movimentacao : Entity
    {
        public int IdContaCorrente { get; set; }
        public int? IdUltimaMovimentacao { get; set; }
        private decimal valor { get; set; }
        public decimal Valor 
        { 
            get
            {
                return valor;
            }
            set
            {
                ValidarCoaf(value);
                valor = value;
            }
        }
        public DateTime DataMovimentacao { get; set; }
        public TipoOperacao Operacao { get; set; }
        [ForeignKey("IdUltimaMovimentacao")]
        public virtual Movimentacao UltimaMovimentacao { get; set; }
        private decimal ultimoSaldo { get; set; }
        public decimal UltimoSaldo 
        {
            get
            {
                return ultimoSaldo;
            }
            set
            {
                ultimoSaldo = value;

                if (UltimaMovimentacao != null)
                {
                    if(UltimaMovimentacao.Operacao == TipoOperacao.Credito)
                    {
                        ultimoSaldo += UltimaMovimentacao.Valor;
                    }
                    else
                    {
                        ultimoSaldo -= UltimaMovimentacao.Valor;
                    }
                    //if(Operacao == TipoOperacao.Debito)
                    //{
                    //    ContaCorrente.ValidarLimiteCredito(ultimoSaldo + (Valor * -1));
                    //}
                }
            }
        }
        public virtual ContaCorrente ContaCorrente { get; set; }
        public virtual Coaf Coaf { get; private set; }
        void ValidarCoaf(decimal valor)
        {
            if(Operacao == TipoOperacao.Credito && valor >= 50000)
            {
                Coaf = new Coaf();
            }
        }
    }

    public enum TipoOperacao
    {
        Credito = 1,
        Debito = 2
    }
}
