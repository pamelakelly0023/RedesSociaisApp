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

            conta.MapGet("{id}", async (IMediator mediator, [AsParameters]ObterContaRequest request) =>
            {
                var id = await mediator.Send(request);
                return Results.Ok(id);
              
            }).WithName("Detalhes Conta").RequireAuthorization();

            
            conta.MapPost(string.Empty,  (IMediator mediator, CriarContaRequest request) =>
            {
                var id = mediator.Send(request);

                return Results.CreatedAtRoute("Detalhes Conta", new { id });

            }).WithName("Cadastrar Conta");


            conta.MapPut("{id}", async (IMediator mediator, [AsParameters]AlterarContaRequest request) =>
            {
                var conta = await mediator.Send(request);

                return !conta.IsSuccess ? Results.NotFound() : Results.NoContent();
            }).WithName("Alterar Conta").RequireAuthorization();

            conta.MapDelete("remover/{id}", async (IMediator mediator, [AsParameters]RemoverContaRequest request) =>
            {
                var conta = await mediator.Send(request);

                return !conta.IsSuccess ? Results.NotFound() : Results.NoContent();
            }).WithName("Exluir Conta").RequireAuthorization();

            conta.MapPut("alterar-senha/{id}", async (IMediator mediator, [AsParameters]AlterarSenhaContaRequest request) =>
            {
                var conta = await mediator.Send(request);

                return !conta.IsSuccess ? Results.NotFound() : Results.NoContent();
            }).WithName("Alterar Senha").RequireAuthorization();
            

            conta.MapPut("login", (LoginInputModel model, IContaService contaService) =>
            {
                var result = contaService.Login(model);
                return !result.IsSuccess ? Results.BadRequest(result) : Results.Ok(result);
            }).WithName("Login Conta");
        } 
    }
}