using AutoMapper;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.ValueObject;
using Puc.Minas.Banking.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.WebApi.Config.Mapper
{
    public class ViewModelToEntityProfile : Profile
    {
        public ViewModelToEntityProfile()
        {
            CreateMap<CorrentistaVM, Correntista>();
            CreateMap<Correntista, CorrentistaVM>();
            CreateMap<EnderecoVM, Endereco>();
            CreateMap<Endereco, EnderecoVM>();
            CreateMap<ContaCorrenteVM, ContaCorrente>();
        }
    }
}
