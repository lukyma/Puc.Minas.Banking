using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puc.Minas.Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puc.Minas.Banking.Test.Domain.Entity
{
    [TestClass]
    public class MovimentacaoTest
    {
        [TestMethod]
        public void ValidarUltimoSaldo()
        {
            Movimentacao movimentacao = new Movimentacao()
            {
                Valor = 100,
                Operacao = TipoOperacao.Credito
            };

            //movimentacao.UltimaMovimentacao.Add(new UltimaMovimentacao()
            //{
            //    UltimoSaldo = 200
            //});

            //Assert.AreEqual(300, movimentacao.UltimaMovimentacao.First().UltimoSaldo);
        }
    }
}
