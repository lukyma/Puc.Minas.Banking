using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.Domain.Interface.Core
{
    public interface IRepository<T> where T : Entity.Entity
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        T Get(int id);
        Task<T> GetAsync(int id);
        IQueryable<T> GetAll();
    }
}
