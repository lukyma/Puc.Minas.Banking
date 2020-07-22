using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Puc.Minas.Banking.Context.Context;
using Puc.Minas.Banking.Context.Repository;
using Puc.Minas.Banking.Context.Repository.Core;
using Puc.Minas.Banking.Domain.Entity;
using Puc.Minas.Banking.Domain.Entity.Notification;
using Puc.Minas.Banking.Domain.Interface;
using Puc.Minas.Banking.Domain.Interface.Core;
using Puc.Minas.Banking.Domain.Interface.Repository;
using Puc.Minas.Banking.Domain.Interface.Service;
using Puc.Minas.Banking.ExternalAPIService;
using Puc.Minas.Banking.Service.ExternalService;
using Puc.Minas.Banking.Service.Notification;
using Puc.Minas.Banking.Service.Service;
using Puc.Minas.Banking.Service.Service.Core;
using Puc.Minas.Banking.Service.Validation;
using System;

namespace Puc.Minas.Banking.IoC
{
    public static class NativeBootstrapInit
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration["PucMinasBankingSqllite:SqliteConnectionString"];
            services.AddDbContext<PucMinasBankingContext>(options => options.UseSqlite(connection));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            RegisterServices(services);
            RegisterRepositories(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IContaCorrenteService, ContaCorrenteService>();
            services.AddScoped<ICorrentistaService, CorrentistaService>();
            services.AddScoped<IMovimentacaoService, MovimentacaoService>();
            services.AddScoped<ICoafApiService, CoafApiService>();
            services.AddTransient<IValidator<Correntista>, CorrentistaValidation>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddScoped<ICorrentistaRepository, CorrentistaRepository>();
            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
        }
    }
}
