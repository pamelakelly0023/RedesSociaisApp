using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedesSociaisApp.Infrastructure.Persistence;

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
                .AddData(configuration);

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
    }
}