using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puc.Minas.Banking.Domain.Interface
{
    public interface IService<T> where T : Entity.Entity
    {
        void Add(T entity);
        void Remove(int id);
        void Update(T entity);
        T Get(int id);
        IQueryable<T> GetAll();
    }
}
