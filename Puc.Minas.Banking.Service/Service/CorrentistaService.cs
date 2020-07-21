using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Interface.Repository;
using Puc.Minas.Banking.Domain.Interface.Service;
using Puc.Minas.Banking.Service.Service.Core;

namespace Puc.Minas.Banking.Service.Service
{
    public class CorrentistaService : Service<Correntista>, ICorrentistaService
    {
        public CorrentistaService(ICorrentistaRepository repository) : base(repository)
        {
        }
    }
}
