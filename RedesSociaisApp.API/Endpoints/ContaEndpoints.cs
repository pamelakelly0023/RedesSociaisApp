using MediatR;
using Microsoft.AspNetCore.Mvc;
using RedesSociaisApp.Application.Requests;
using RedesSociaisApp.Application.Requests.Conta;

namespace RedesSociaisApp.API.Endpoints
{
    public static class ContaEndpoints
    {
        public static void MapContaEndpoint(this IEndpointRouteBuilder app)
        {
            var conta = app.MapGroup("/api/v1/conta");

            conta.MapGet("detalhes/{id}", static async (IMediator mediator, int id)
                => await mediator.Send(new ObterContaRequest(id)))
                    .WithName("Detalhes Conta")
                    .RequireAuthorization();
            
            conta.MapPost("criar/", static async (IMediator mediator, CriarContaRequest request)
                => await mediator.Send(request))
                    .WithName("Cadastrar Conta");

            conta.MapPut("alterar/{id}", static async (IMediator mediator, int id, AlterarContaRequest request) => {
                if(id != request.Id)
                {
                    Results.BadRequest(); 
                } 

                await mediator.Send(request);
            }); 

            conta.MapDelete("remover/{id}", static async (IMediator mediator, int id)
                => await mediator.Send(new RemoverContaRequest(id)))
                    .WithName("Exluir Conta")
                    .RequireAuthorization();

            conta.MapPut("alterar-senha/{id}", static async (IMediator mediator, int id, AlterarSenhaContaRequest request) => {
                if(id != request.Id)
                {
                    Results.BadRequest(); 
                }

                 await mediator.Send(request);
            })
            .WithName("Alterar senha Conta")
            .RequireAuthorization();
            
            conta.MapPut("login", static async (IMediator mediator, LoginContaRequest request) 
                => await mediator.Send(request))
                    .WithName("Login Conta");
        } 
    }
}