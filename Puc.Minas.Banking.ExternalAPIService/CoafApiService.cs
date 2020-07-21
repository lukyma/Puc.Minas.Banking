using Newtonsoft.Json;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.ExternalAPIService.Base;
using Puc.Minas.Banking.Service.ExternalService;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.ExternalAPIService
{
    public class CoafApiService : ICoafApiService
    {
        private HttpClient httpClient { get; set; }
        public async Task EnviarNotificacaoCoaf(decimal valor, ContaCorrente contaCorrente)
        {
            httpClient = HttpClientMock(new { status = "sucesso" });

            object dadosCoaf = new
            {
                valor,
                contaCorrente.Correntista.Cpf
            };

            var retorno = await httpClient.SendAsync(new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("coaf"),
                Content = new StringContent(JsonConvert.SerializeObject(dadosCoaf), 
                                            Encoding.UTF8, 
                                            "application/json")
            });

            if (!retorno.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao enviar dados para o coaf");
            }
        }

        private HttpClient HttpClientMock(object modelResponse, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            httpClient = new HttpClientTest(modelResponse, statusCode);

            return httpClient;
        }
    }
}
