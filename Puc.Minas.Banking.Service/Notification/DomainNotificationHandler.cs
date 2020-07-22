using FluentValidation;
using Puc.Minas.Banking.Domain.Entity.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.Service.Notification
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        public DomainNotificationHandler()
        {
            domainNotifications = new List<DomainNotification>();
        }
        private List<DomainNotification> domainNotifications;
        public List<DomainNotification> GetNotifications()
        {
            return domainNotifications;
        }

        public void HandleAsync(DomainNotification notification)
        {
            domainNotifications.Add(notification);
        }

        public bool HandleValidateAsync<T>(IValidator<T> notification, T entity)
        {
            var validate = notification.Validate<T>(entity);
            foreach (var item in validate.Errors)
            {
                HandleAsync(new DomainNotification(item.ErrorCode, item.ErrorMessage));
            }

            return validate.IsValid;
        }

        public bool HasNotifications()
        {
            return domainNotifications.Any();
        }
    }
}
