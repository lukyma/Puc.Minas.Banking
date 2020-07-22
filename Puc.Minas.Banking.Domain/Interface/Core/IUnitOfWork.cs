using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.Domain.Interface.Core
{
    public interface IUnitOfWork
    {
        IDisposable BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
