using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace RedesSociaisApp.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {
            services
                .AddMediator();

            return services;
        }

        // Adicionar os serviços de Aplicação

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            
            return services;
        }

    }
}