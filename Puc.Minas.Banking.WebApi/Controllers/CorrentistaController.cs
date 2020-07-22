using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Puc.Minas.Banking.Context.Context;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Entity.Notification;
using Puc.Minas.Banking.Domain.Interface.Core;
using Puc.Minas.Banking.Domain.Interface.Service;
using Puc.Minas.Banking.Service.Validation;
using Puc.Minas.Banking.WebApi.Helpers.Filters;

namespace Puc.Minas.Banking.WebApi.Controllers
{
    [Route("api/correntista")]
    [ApiController]
    public class CorrentistaController : BaseController
    {
        private ICorrentistaService correntistaService { get; }
        private IUnitOfWork unitOfWork { get; }
        public CorrentistaController(ICorrentistaService correntistaService, 
                                     IUnitOfWork unitOfWork,
                                     INotificationHandler<DomainNotification> notification):base(notification)
        {
            this.correntistaService = correntistaService;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Correntista), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Correntista correntista)
        {
            correntistaService.Add(correntista);
            unitOfWork.SaveChanges();
            return Response(correntista, $"api/correntista/{correntista.Id}");
        }

        [HttpPut, Route("{id}")]
        [ProducesResponseType(typeof(Correntista), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(int id, [FromBody] Correntista correntista)
        {
            correntista.Id = id;
            correntistaService.Update(correntista);
            await unitOfWork.SaveChangesAsync();
            return Response(correntista);
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
        [ProducesResponseType(typeof(Correntista), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> Get(int id)
        {
            return Response(correntistaService.Get(id));
        }
    }
}
