using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
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
                .AddServices();

            return services;
        }

        // Adicionar os serviços de Aplicação
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            
            services.AddScoped<IContaService, ContaService>();
            // services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}