using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.Domain.Entity.Notification
{
    public interface INotificationHandler<T> where T : class
    {

        void HandleAsync(T notification);
        bool HandleValidateAsync<VEntity>(IValidator<VEntity> notification, VEntity entity);

        List<T> GetNotifications();

        bool HasNotifications();
    }
}
