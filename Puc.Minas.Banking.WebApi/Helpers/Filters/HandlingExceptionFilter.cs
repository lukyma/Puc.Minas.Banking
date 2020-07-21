using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Puc.Minas.Banking.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.WebApi.Helpers.Filters
{
    public class HandlingExceptionFilter : ControllerBase, IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            object genericException = new
            {
                code = "500",
                message = "Ocorreu um erro não identificado"
            };
            if (context.Exception is RuleException)
            {
                RuleException ruleException = context.Exception as RuleException;

                genericException = new
                {
                    code = ruleException.Code,
                    message = ruleException.Message
                };

                context.Result = BadRequest(genericException);
                return;
            }
            context.Result = BadRequest(genericException);
        }
    }
}
