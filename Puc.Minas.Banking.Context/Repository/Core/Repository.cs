using Microsoft.EntityFrameworkCore;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Interface.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
