using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Entity.Notification;
using Puc.Minas.Banking.Domain.Interface;
using Puc.Minas.Banking.Domain.Interface.Core;
using Puc.Minas.Banking.Domain.Interface.Service;
using Puc.Minas.Banking.WebApi.Helpers.Filters;

namespace Puc.Minas.Banking.WebApi.Controllers
{
    [Route("api/contacorrente")]
    [ApiController]
    [ServiceFilter(typeof(HandlingExceptionFilter))]
    public class ContaCorrenteController : BaseController
    {
        private IContaCorrenteService contaCorrenteService { get; }
        private IMovimentacaoService movimentacaoService { get; }
        private IUnitOfWork unitOfWork { get; }
        public ContaCorrenteController(IMovimentacaoService movimentacaoService,
                                       IContaCorrenteService contaCorrenteService,
                                       IUnitOfWork unitOfWork,
                                       INotificationHandler<DomainNotification> notification):base(notification)
        {
            this.movimentacaoService = movimentacaoService;
            this.contaCorrenteService = contaCorrenteService;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("credito/{valor}/conta/{numeroConta}/digito/{digito}")]
        [ProducesResponseType(typeof(ContaCorrente), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreditarValor(decimal valor, int numeroConta, int digito)
        {
            Movimentacao movimentacao = movimentacaoService.AdicionarMovimentacao(valor, numeroConta, digito, TipoOperacao.Credito);
            await unitOfWork.SaveChangesAsync();
            return Response(movimentacao.ContaCorrente);
        }
        [HttpPost]
        [Route("debito/{valor}/conta/{numeroConta}/digito/{digito}")]
        [ProducesResponseType(typeof(ContaCorrente), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DebitarValor(decimal valor, int numeroConta, int digito)
        {
            Movimentacao movimentacao = movimentacaoService.AdicionarMovimentacao(valor, numeroConta, digito, TipoOperacao.Debito);
            await unitOfWork.SaveChangesAsync();
            return Response(movimentacao.ContaCorrente);
        }
    }
}
