using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.Domain.Interface
{
    public interface IService<T> where T : Entity.Entity
    {
        void Add<V>(T entity) where V : AbstractValidator<T>;
        void Add(T entity);
        void Remove(int id);
        void Update<V>(T entity) where V : AbstractValidator<T>;
        void Update(T entity);
        T Get(int id);
        Task<T> GetAsync(int id);
        IQueryable<T> GetAll();
    }
}
