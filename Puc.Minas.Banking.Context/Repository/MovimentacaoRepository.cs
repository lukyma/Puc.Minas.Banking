using Microsoft.EntityFrameworkCore;
using Puc.Minas.Banking.Context.Context;
using Puc.Minas.Banking.Context.Repository.Core;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puc.Minas.Banking.Context.Repository
{
    public class MovimentacaoRepository : Repository<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(PucMinasBankingContext context) : base(context)
        {
        }

        public override IQueryable<Movimentacao> GetAll()
        {
            return base.GetAll().Include(o => o.UltimaMovimentacao);
        }
    }
}
