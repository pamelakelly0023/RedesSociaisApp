using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RedesSociaisApp.Application.Requests;
using RedesSociaisApp.Application.Services;
using RedesSociaisApp.Infrastructure.Auth;
using SQLitePCL;

namespace RedesSociaisApp.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {
            services
                .AddServices()
                .AddMediator();

            return services;
        }

        // Adicionar os serviços de Aplicação
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            
            services.AddScoped<IContaService, ContaService>();
            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            
            return services;
        }

    }
}