using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedesSociaisApp.Domain.Repositories;
using RedesSociaisApp.Infrastructure.Auth;
using RedesSociaisApp.Infrastructure.Persistence;
using RedesSociaisApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;

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
                .AddRepositories()
                .AddAuth(configuration);

            return services;
        }

        private static IServiceCollection AddData(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString = configuration.GetConnectionString("RedesSociaisDb");         

            services.AddDbContext<RedesSociaisDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
 
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IPublicacaoRepository, PublicacaoRepository>();

            return services;
            
        }

        private static IServiceCollection AddAuth(this IServiceCollection services,  IConfiguration configuration)
        {
            services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuration["JWT:Audience"],
                    ValidIssuer = configuration["JWT:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
                };
                    });

                services.AddScoped<IAuthService, AuthService>();

                // services.AddIdentity<IdentityUser, IdentityRole>()
                //     .AddEntityFrameworkStores<RedesSociaisDbContext>()
                //     .AddDefaultTokenProviders();
                    
                return services;
            }
        }
    }
