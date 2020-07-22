using Microsoft.EntityFrameworkCore;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Interface.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.Context.Repository.Core
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected DbContext Db { get; }
        protected DbSet<T> DbSet { get; }

        public Repository(DbContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public void Update(T entity, params object[] id)
        {
            DbSet.Update(DbSet.Find(id)).CurrentValues.SetValues(entity);
        }
    }
}
