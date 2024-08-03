using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RedesSociaisApp.Application.Validators;

namespace RedesSociaisApp.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {
            services
                .AddMediator()
                .AddValidation();

            return services;
        }

        // Adicionar os serviços de Aplicação

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            
            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CriarContaValidator>();

            return services;
        }

    }
}