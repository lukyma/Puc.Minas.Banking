using FluentValidation;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Entity.Notification;
using Puc.Minas.Banking.Domain.Interface.Repository;
using Puc.Minas.Banking.Domain.Interface.Service;
using Puc.Minas.Banking.Service.Service.Core;
using System.Linq;

namespace Puc.Minas.Banking.Service.Service
{
    public class CorrentistaService : Service<Correntista>, ICorrentistaService
    {
        public CorrentistaService(ICorrentistaRepository repository,
                                  INotificationHandler<DomainNotification> notificationHandler,
                                  IValidator<Correntista> validator)
            : base(repository, notificationHandler, validator)
        {
        }

        public override void Add(Correntista entity)
        {
            if(!NotificationHandler.HandleValidateAsync(Validator, entity))
            {
                return;
            }
            if(Repository.GetAll().Any(o => o.Cpf == entity.Cpf))
            {
                NotificationHandler.HandleAsync(new DomainNotification("004", "Já existe um cliente com o CPF informado!"));
                return;
            }
            Add(entity);
        }
    }
}
