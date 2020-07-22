using FluentValidation;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Entity.Notification;
using Puc.Minas.Banking.Domain.Interface;
using Puc.Minas.Banking.Domain.Interface.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.Service.Service.Core
{
    public class Service<T> : IService<T> where T : Entity
    {
        protected IRepository<T> Repository { get; set; }
        protected INotificationHandler<DomainNotification> NotificationHandler { get; }
        protected IValidator<T> Validator { get; }
        public Service(IRepository<T> repository,
                       INotificationHandler<DomainNotification> notificationHandler,
                       IValidator<T> rules = null)
        {
            Repository = repository;
            NotificationHandler = notificationHandler;
            this.Validator = rules;
        }
        public virtual void Add<V>(T entity) where V : AbstractValidator<T>
        {
            if(Validator != null)
            {
                Validate(entity, Validator);
            }

            if (!NotificationHandler.HasNotifications())
            {
                Repository.Add(entity);
            }
        }

        public virtual void Add(T entity)
        {
            if (Validator != null)
            {
                Validate(entity, Validator);
            }

            if (!NotificationHandler.HasNotifications())
            {
                Repository.Add(entity);
            }
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

        public void Update<V>(T entity) where V : AbstractValidator<T>
        {
            if (Validator != null)
            {
                Validate(entity, Validator);
            }

            if (!NotificationHandler.HasNotifications())
            {
                Repository.Update(entity);
            }
        }

        private void Validate(T obj, IValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            foreach (var item in validator.Validate(obj).Errors)
            {
                NotificationHandler.HandleAsync(new DomainNotification(item.ErrorCode, item.ErrorMessage));
            }
        }

        public void Update(T entity)
        {
            if (Validator != null)
            {
                Validate(entity, Validator);
            }
            if (!NotificationHandler.HasNotifications())
            {
                Repository.Update(entity);
            }
        }

        public async Task<T> GetAsync(int id)
        {
            return await Repository.GetAsync(id);
        }

        public void Update(T entity, params object[] id)
        {
            Repository.Update(entity, id);
        }
    }
}
