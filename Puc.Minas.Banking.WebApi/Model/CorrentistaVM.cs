using Puc.Minas.Banking.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.WebApi.Model
{
    public class CorrentistaVM
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public virtual EnderecoVM Endereco { get; set; }
    }
}
