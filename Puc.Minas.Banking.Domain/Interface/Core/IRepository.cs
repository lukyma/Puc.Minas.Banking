using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puc.Minas.Banking.Domain.Interface.Core
{
    public interface IRepository<T> where T : Entity.Entity
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        T Get(int id);
        IQueryable<T> GetAll();
    }
}
