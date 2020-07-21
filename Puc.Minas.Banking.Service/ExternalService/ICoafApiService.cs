using Puc.Minas.Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.Service.ExternalService
{
    public interface ICoafApiService
    {
        Task EnviarNotificacaoCoaf(decimal valor, ContaCorrente contaCorrente);
    }
}
