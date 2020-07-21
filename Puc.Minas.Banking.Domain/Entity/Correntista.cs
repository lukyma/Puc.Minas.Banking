using Puc.Minas.Banking.Domain.Exception;
using Puc.Minas.Banking.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Puc.Minas.Banking.Domain.Entity
{
    public class Correntista : AggregateRoot
    {
        public string Nome { get; set; }
        private string cpf { get; set; }
        public string Cpf 
        {
            get
            {
                return cpf;
            }
            set 
            { 
                if(Regex.IsMatch(value, @"^\d{3}\.\d{3}\.\d{3}\-\d{2}$"))
                {
                    cpf = value;
                }
                else
                {
                    throw new RuleException("O campo CPF está em um formato inválido!", "001");
                }
            } 
        }
        private string telefone { get; set; }
        public string Telefone
        {
            get { return telefone; }
            set
            {
                if(Regex.IsMatch(value, @"^([0-9]{2}|\([0-9]{2}\))-([0-9]{4}|[0-9]{5})-[0-9]{4}$"))
                {
                    telefone = value;
                }
                else
                {
                    throw new RuleException("O campo telefone está em um formato inválido!", "002");
                }
            }
        }
        public virtual ICollection<ContaCorrente> ContaCorrentes { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
