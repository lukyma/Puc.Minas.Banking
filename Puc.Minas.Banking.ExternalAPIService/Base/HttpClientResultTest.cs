using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.ExternalAPIService.Base
{
    internal static class HttpResultTest
    {
        public static Task<HttpResponseMessage> GetHttpSuccessResponseMessage(object model)
        {
            var message = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(model))
            };
            return Task.FromResult(message);
        }

        public static Task<HttpResponseMessage> GetHttpBadRequestResponseMessage(object model)
        {
            var message = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent(JsonConvert.SerializeObject(model))
            };
            return Task.FromResult(message);
        }
    }
}
