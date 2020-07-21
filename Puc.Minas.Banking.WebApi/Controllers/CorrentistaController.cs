﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Puc.Minas.Banking.Context.Context;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Interface.Core;
using Puc.Minas.Banking.Domain.Interface.Service;

namespace Puc.Minas.Banking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrentistaController : ControllerBase
    {
        private ICorrentistaService correntistaService { get; }
        private IUnitOfWork unitOfWork { get; }
        public CorrentistaController(ICorrentistaService correntistaService, IUnitOfWork unitOfWork)
        {
            this.correntistaService = correntistaService;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Correntista correntista)
        {
            correntistaService.Add(correntista);
            unitOfWork.SaveChanges();
            return Ok(correntista);
        }
    }
}