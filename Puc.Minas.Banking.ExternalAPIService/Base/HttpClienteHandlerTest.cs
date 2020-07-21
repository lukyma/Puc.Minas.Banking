using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.ExternalAPIService.Base
{
    public class HttpClienteHandlerTest : HttpClientHandler
    {
        private readonly object model;
        private readonly HttpStatusCode statusCode;

        public HttpClienteHandlerTest(object model, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            this.model = model;
            this.statusCode = statusCode;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (statusCode == HttpStatusCode.OK)
            {
                return HttpResultTest.GetHttpSuccessResponseMessage(model);
            }
            else
            {
                return HttpResultTest.GetHttpBadRequestResponseMessage(model);
            }
        }
    }
}
