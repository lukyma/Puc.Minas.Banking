using Puc.Minas.Banking.Domain.Exception;
using Puc.Minas.Banking.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Puc.Minas.Banking.Domain.Entity
{
    public class Correntista : AggregateRoot
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public virtual ICollection<ContaCorrente> ContaCorrentes { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
