using System;
using System.Collections.Generic;
using System.Text;

namespace Puc.Minas.Banking.Domain.Entity.Notification
{
    public class DomainNotification
    {
        public DomainNotification(string code, string message)
        {
            Code = code;
            Message = message;
        }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
