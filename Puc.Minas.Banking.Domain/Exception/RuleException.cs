using System;
using System.Collections.Generic;
using System.Text;

namespace Puc.Minas.Banking.Domain.Exception
{
    public class RuleException : System.Exception
    {
        public string Code { get; set; }
        public RuleException(string message, string code) : base(message)
        {
            Code = code;
        }
    }
}
