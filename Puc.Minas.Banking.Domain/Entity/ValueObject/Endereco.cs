using Puc.Minas.Banking.Domain.Entity.Core;

namespace Puc.Minas.Banking.Domain.ValueObject
{
    public class Endereco : ObjectValue
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
    }
}
