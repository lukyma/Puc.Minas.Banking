using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Puc.Minas.Banking.Context.Context;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Entity.Notification;
using Puc.Minas.Banking.Domain.Interface.Core;
using Puc.Minas.Banking.Domain.Interface.Service;
using Puc.Minas.Banking.Service.Validation;
using Puc.Minas.Banking.WebApi.Helpers.Filters;
using Puc.Minas.Banking.WebApi.Model;

namespace Puc.Minas.Banking.WebApi.Controllers
{
    [Route("api/correntista")]
    [ApiController]
    public class CorrentistaController : BaseController
    {
        private ICorrentistaService correntistaService { get; }
        private IUnitOfWork unitOfWork { get; }
        private IMapper mapper { get; }
        public CorrentistaController(ICorrentistaService correntistaService, 
                                     IUnitOfWork unitOfWork,
                                     INotificationHandler<DomainNotification> notification,
                                     IMapper mapper):base(notification)
        {
            this.correntistaService = correntistaService;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CorrentistaVM), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] CorrentistaVM correntista)
        {
            Correntista request = mapper.Map<CorrentistaVM, Correntista>(correntista);
            request.ContaCorrentes = new List<ContaCorrente>();
            correntistaService.Add(request);
            await unitOfWork.SaveChangesAsync();
            return Response(correntista, $"api/correntista/{request.Id}");
        }

        [HttpPut, Route("{id}")]
        [ProducesResponseType(typeof(CorrentistaVM), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(int id, [FromBody] CorrentistaVM correntista)
        {
            Correntista request = mapper.Map<CorrentistaVM, Correntista>(correntista);
            request.Id = id;
            correntistaService.Update(request);
            await unitOfWork.SaveChangesAsync();
            return Response(mapper.Map<Correntista, CorrentistaVM>(request));
        }

        [HttpDelete, Route("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int id)
        {
            correntistaService.Remove(id);
            await unitOfWork.SaveChangesAsync();
            return Response();
        }

        [HttpGet, Route("{id}")]
        [ProducesResponseType(typeof(CorrentistaVM), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> Get(int id)
        {
            return Response(await correntistaService.GetAsync(id));
        }
    }
}
