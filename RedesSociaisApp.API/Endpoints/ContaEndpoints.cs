using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Requests;
using RedesSociaisApp.Application.Requests.Conta;
using RedesSociaisApp.Application.Services;

namespace RedesSociaisApp.API.Endpoints
{
    public static class ContaEndpoints
    {
        public static void MapContaEndpoint(this IEndpointRouteBuilder app)
        {
            var conta = app.MapGroup("/api/v1/conta");

            conta.MapGet("detalhes/{id}", static async (IMediator mediator, int id)
                => await mediator.Send(new ObterContaRequest(id)))
                    .WithName("Detalhes Conta").RequireAuthorization();
            
            conta.MapPost("criar", static async (IMediator mediator, CriarContaRequest request)
                => await mediator.Send(request))
                    .WithName("Cadastrar Conta");

            conta.MapPut("alterar", static async (IMediator mediator, AlterarContaRequest request)
                => await mediator.Send(request))
                    .WithName("Alterar Conta").RequireAuthorization();

            conta.MapDelete("remover/{id}", async (IMediator mediator, [AsParameters]RemoverContaRequest request)
                => await mediator.Send(request))
                    .WithName("Exluir Conta").RequireAuthorization();

            conta.MapPut("alterar-senha/{id}", static async (IMediator mediator, [AsParameters]AlterarSenhaContaRequest request)
                => await mediator.Send(request))
                    .WithName("Alterar Senha").RequireAuthorization();
            

            conta.MapPut("login", (LoginInputModel model, IContaService contaService) =>
            {
                var result = contaService.Login(model);
                return !result.IsSuccess ? Results.BadRequest(result) : Results.Ok(result);
            }).WithName("Login Conta");
        } 
    }
}