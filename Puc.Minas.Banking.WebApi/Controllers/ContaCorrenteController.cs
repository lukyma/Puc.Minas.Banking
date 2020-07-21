using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Interface;
using Puc.Minas.Banking.Domain.Interface.Core;
using Puc.Minas.Banking.Domain.Interface.Service;

namespace Puc.Minas.Banking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        private IContaCorrenteService contaCorrenteService { get; }
        private IMovimentacaoService movimentacaoService { get; }
        private IUnitOfWork unitOfWork { get; }
        public ContaCorrenteController(IMovimentacaoService movimentacaoService,
                                       IContaCorrenteService contaCorrenteService,
                                       IUnitOfWork unitOfWork)
        {
            this.movimentacaoService = movimentacaoService;
            this.contaCorrenteService = contaCorrenteService;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("credito/{valor}/conta/{numeroConta}/digito/{digito}")]
        public async Task<IActionResult> CreditarValor(decimal valor, int numeroConta, int digito)
        {
            Movimentacao movimentacao = movimentacaoService.AdicionarMovimentacao(valor, numeroConta, digito, TipoOperacao.Credito);
            unitOfWork.SaveChanges();
            ContaCorrente contaCorrente = contaCorrenteService.Get(movimentacao.IdContaCorrente);
            return Ok(contaCorrente);
        }
        [HttpPost("debito/{valor}/conta/{numeroConta}/digito/{digito}")]
        public async Task<IActionResult> DebitarValor(decimal valor, int numeroConta, int digito)
        {
            Movimentacao movimentacao = movimentacaoService.AdicionarMovimentacao(valor, numeroConta, digito, TipoOperacao.Debito);
            unitOfWork.SaveChanges();
            ContaCorrente contaCorrente = contaCorrenteService.Get(movimentacao.IdContaCorrente);
            return Ok(contaCorrente);
        }
    }
}
