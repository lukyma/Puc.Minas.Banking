using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Entity.Notification;
using Puc.Minas.Banking.Domain.Interface;
using Puc.Minas.Banking.Domain.Interface.Core;
using Puc.Minas.Banking.Domain.Interface.Repository;
using Puc.Minas.Banking.Service.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puc.Minas.Banking.Service.Service
{
    public class ContaCorrenteService : Service<ContaCorrente>, IContaCorrenteService
    {
        public ContaCorrenteService(IContaCorrenteRepository repository,
                                    INotificationHandler<DomainNotification> notificationHandler) 
            : base(repository, notificationHandler)
        {

        }
    }
}
