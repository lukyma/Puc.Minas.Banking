using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Interface;
using Puc.Minas.Banking.Domain.Interface.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puc.Minas.Banking.Service.Service.Core
{
    public class Service<T> : IService<T> where T : Entity
    {
        protected IRepository<T> Repository { get; set; }
        public Service(IRepository<T> repository)
        {
            Repository = repository;
        }
        public void Add(T entity)
        {
            Repository.Add(entity);
        }

        public T Get(int id)
        {
            return Repository.Get(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return Repository.GetAll();
        }

        public void Remove(int id)
        {
            Repository.Remove(Get(id));
        }

        public void Update(T entity)
        {
            Repository.Update(entity);
        }
    }
}
