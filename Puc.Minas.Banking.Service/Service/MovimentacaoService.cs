using Microsoft.EntityFrameworkCore;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Entity.Notification;
using Puc.Minas.Banking.Domain.Interface.Core;
using Puc.Minas.Banking.Domain.Interface.Repository;
using Puc.Minas.Banking.Domain.Interface.Service;
using Puc.Minas.Banking.Service.ExternalService;
using Puc.Minas.Banking.Service.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puc.Minas.Banking.Service.Service
{
    public class MovimentacaoService : Service<Movimentacao>, IMovimentacaoService
    {
        private IContaCorrenteRepository contaCorrenteRepository { get; }
        private ICoafApiService coafApiService { get; }
        public MovimentacaoService(IMovimentacaoRepository movimentacaoRepository,
                                   IContaCorrenteRepository contaCorrente,
                                   ICoafApiService coafApiService,
                                   INotificationHandler<DomainNotification> notificationHandler)
            : base(movimentacaoRepository, notificationHandler)
        {
            this.contaCorrenteRepository = contaCorrente;
            this.coafApiService = coafApiService;
        }

        public override IQueryable<Movimentacao> GetAll()
        {
            return base.GetAll();
        }

        public Movimentacao Debitar(decimal valor, int numeroConta, int digito)
        {
            return RegistarMovimentacao(valor, numeroConta, digito, TipoOperacao.Debito);
        }

        public Movimentacao Depositar(decimal valor, int numeroConta, int digito)
        {
            return RegistarMovimentacao(valor, numeroConta, digito, TipoOperacao.Credito);
        }

        private Movimentacao RegistarMovimentacao(decimal valor, int numeroConta, int digito, TipoOperacao operacao)
        {
            ContaCorrente contaCorrente = contaCorrenteRepository.GetAll().FirstOrDefault(o => o.Numero == numeroConta && o.Digito == digito);

            Movimentacao movimentacao = contaCorrente.Movimentar(valor, operacao);

            if (movimentacao.Coaf != null)
            {
                coafApiService.EnviarNotificacaoCoaf(valor, contaCorrente);
            }

            return movimentacao;
        }
    }
}
