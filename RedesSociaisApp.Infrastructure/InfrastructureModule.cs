using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedesSociaisApp.Domain.Repositories;
using RedesSociaisApp.Infrastructure.Persistence;
using RedesSociaisApp.Infrastructure.Repositories;

namespace RedesSociaisApp.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services
                .AddData(configuration)
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddData(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString = configuration.GetConnectionString("RedesSociaisDb");         
            services.AddDbContext<RedesSociaisDbContext>(
                options => options.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString)));
                
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IPublicacaoRepository, PublicacaoRepository>();

            return services;
            
        }
    }
}