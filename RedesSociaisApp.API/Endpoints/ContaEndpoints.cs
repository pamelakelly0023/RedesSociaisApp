using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using RedesSociaisApp.API.Extensions;
using RedesSociaisApp.Application.Exceptions;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Requests;
using RedesSociaisApp.Application.Requests.Conta;
using RedesSociaisApp.Application.Responses;

namespace RedesSociaisApp.API.Endpoints
{
    public static class ContaEndpoints
    {
        public static void MapContaEndpoint(this IEndpointRouteBuilder app)
        {
            var conta = app.MapGroup("/api/v1/conta")
                .WithTags("Conta");
            
            conta.MapPost("/", async (IMediator mediator, [FromBody]CriarContaRequest request) 
                => await mediator.SendCommand(request))
                    .WithDisplayName("Endpoint para Cadastrar Conta")
                    .WithName("CadastrarConta")
                    .Produces<CriarContaResponse>(201);

            conta.MapPut("/{id}", async (IMediator mediator, int id, [FromBody]AlterarContaRequest request) 
                =>  await mediator.Send(request))
                    .WithDisplayName("Endpoint para Alterar dados de Conta do Usuário")
                    .WithName("Alterar Conta")
                    .Produces<Result>(204)
                    .RequireAuthorization();

            conta.MapDelete("/{id}", static async (IMediator mediator, [FromBody]RemoverContaRequest request)
                =>  await mediator.Send(request))
                    .WithDisplayName("Endpoint para Excluir Conta do Usuário")
                    .WithName("Exluir Conta")
                    .Produces<Result>(204)
                    .Produces<Result>(404)
                    .RequireAuthorization();

            conta.MapPut("alterar-senha/{id}", static async (IMediator mediator, int id, [FromBody]AlterarSenhaContaRequest request) 
                => await mediator.Send(request))
                    .WithName("Alterar senha Conta");
                    // .RequireAuthorization();
            
            conta.MapPut("login", static async (IMediator mediator, [FromBody]LoginContaRequest request) 
                => await mediator.Send(request) switch
                {
                    (true, _) => Results.StatusCode(200),
                    (_, _, var erro) => TratarErro(erro!)
                })
                .Produces(200, typeof(LoginViewModel))
                .WithName("Login Conta");
        } 
        private static IResult TratarErro(Exception erro) => erro switch
        {
            ModeloInvalidoException e => Results.BadRequest(e.Erros),
            Exception e => Results.StatusCode(500)
        };          
}
}