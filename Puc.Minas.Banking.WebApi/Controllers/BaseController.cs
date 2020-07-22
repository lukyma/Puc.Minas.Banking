using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puc.Minas.Banking.Domain.Entity.Notification;

namespace Puc.Minas.Banking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected INotificationHandler<DomainNotification> Notification { get; }
        public BaseController(INotificationHandler<DomainNotification> notification)
        {
            Notification = notification;
        }

        /// <summary>
        /// Notificação
        /// </summary>
        protected IEnumerable<DomainNotification> Notifications => Notification.GetNotifications();

        /// <summary>
        /// Validação de dados
        /// </summary>
        /// <returns></returns>
        protected bool IsValidOperation()
        {
            return (!Notification.HasNotifications());
        }

        /// <summary>
        /// Retorno da validação
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected new IActionResult Response(object result = null, string uri = null)
        {
            try
            {
                if (IsValidOperation())
                {
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else if (uri != null)
                    {
                        return Created(uri, result);
                    }
                    else
                    {
                        return NoContent();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    erros = new object[]
                    {
                        new
                        {
                            codigo = "500",
                            mensagem = "Ocorreu algum erro não esperado.",
                            customError = ex
                        }
                    }
                });

            }

            var erros = new
            {
                erros = Notifications.Select(n =>
                {
                    return n;
                })
            };
            return BadRequest(erros);
        }

        /// <summary>
        /// Notificação de erros no modelstate
        /// </summary>
        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        /// <summary>
        /// Notificação de Erros
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        protected void NotifyError(string code, string message)
        {
            Notification.HandleAsync(new DomainNotification(code, message));
        }
    }
}
