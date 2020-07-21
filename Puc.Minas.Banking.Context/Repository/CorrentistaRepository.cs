using Microsoft.EntityFrameworkCore;
using Puc.Minas.Banking.Context.Context;
using Puc.Minas.Banking.Context.Repository.Core;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Puc.Minas.Banking.Context.Repository
{
    public class CorrentistaRepository : Repository<Correntista>, ICorrentistaRepository
    {
        public CorrentistaRepository(PucMinasBankingContext context) : base(context)
        {
        }
    }
}
