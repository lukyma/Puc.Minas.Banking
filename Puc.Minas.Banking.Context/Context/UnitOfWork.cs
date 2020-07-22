using Microsoft.EntityFrameworkCore.Storage;
using Puc.Minas.Banking.Domain.Interface.Core;
using System;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.Context.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private PucMinasBankingContext context { get; }
        private IDbContextTransaction transaction { get; set; }
        public UnitOfWork(PucMinasBankingContext context)
        {
            this.context = context;
        }
        public IDisposable BeginTransaction()
        {
            transaction = context.Database.BeginTransaction() as IDbContextTransaction;
            return transaction;
        }

        public void CommitTransaction()
        {
            if (transaction == null)
                throw new ArgumentNullException("O bloco de transação não foi iniciado.");

            transaction.Commit();
        }

        public void RollbackTransaction()
        {
            if (transaction == null)
                throw new ArgumentNullException("O bloco de transação não foi iniciado.");

            transaction.Rollback();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
