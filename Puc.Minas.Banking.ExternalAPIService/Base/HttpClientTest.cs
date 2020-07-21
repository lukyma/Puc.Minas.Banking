using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Puc.Minas.Banking.ExternalAPIService.Base
{
    public class HttpClientTest : HttpClient
    {
        public HttpClientTest(object model, HttpStatusCode statusCode = HttpStatusCode.OK)
            : base(new HttpClienteHandlerTest(model, statusCode))
        {
            BaseAddress = new Uri("http://www.urlbase.com.br/");
        }
        public HttpClientTest()
            : base()
        {
            BaseAddress = new Uri("http://www.urlbase.com.br/");
        }
    }
}
