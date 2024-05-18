using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace RedesSociaisApp.API.Endpoints
{
    public static class ContasEndpoints
    {
        public static void RegisterContasEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/cadastro", () => "teste");
        }
    }
}