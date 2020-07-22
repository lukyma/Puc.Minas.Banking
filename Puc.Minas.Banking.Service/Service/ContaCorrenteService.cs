using FluentValidation;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Entity.Notification;
using Puc.Minas.Banking.Domain.Interface;
using Puc.Minas.Banking.Domain.Interface.Core;
using Puc.Minas.Banking.Domain.Interface.Repository;
using Puc.Minas.Banking.Service.ExternalService;
using Puc.Minas.Banking.Service.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puc.Minas.Banking.Service.Service
{
    public class ContaCorrenteService : Service<ContaCorrente>, IContaCorrenteService
    {
        private ICoafApiService coafApiService { get; }
        private IValidator<Movimentacao> validator { get; }
        public ContaCorrenteService(IContaCorrenteRepository repository,
                                    INotificationHandler<DomainNotification> notificationHandler,
                                    ICoafApiService coafApiService,
                                    IValidator<Movimentacao> validator) 
            : base(repository, notificationHandler)
        {
            this.coafApiService = coafApiService;
            this.validator = validator;
        }

        public Movimentacao Debitar(decimal valor, int numeroConta, int digito)
        {
            return RegistarOperacao(valor, numeroConta, digito, TipoOperacao.Debito);
        }

        public Movimentacao Depositar(decimal valor, int numeroConta, int digito)
        {
            return RegistarOperacao(valor, numeroConta, digito, TipoOperacao.Credito);
        }

        private Movimentacao RegistarOperacao(decimal valor, int numeroConta, int digito, TipoOperacao operacao)
        {
            ContaCorrente contaCorrente = GetAll().FirstOrDefault(o => o.Numero == numeroConta && o.Digito == digito);

            Movimentacao movimentacao = contaCorrente.Movimentar(valor, operacao);

            if (NotificationHandler.HandleValidateAsync(validator, movimentacao))
            {
                Update(contaCorrente);

                if (movimentacao.Coaf != null)
                {
                    coafApiService.EnviarNotificacaoCoaf(valor, contaCorrente);
                }
            }

            return movimentacao;
        }
    }
}
