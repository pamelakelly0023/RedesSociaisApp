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


            conta.MapPut("{id:int}", (IMediator mediator, AlterarContaRequest request) =>
            {
                var conta = mediator.Send(request);

                return !conta.Result.IsSuccess ? Results.NotFound() : Results.NoContent();
            }).WithName("Alterar Conta").RequireAuthorization();

            // Ajustar os seguintes endPoints para utilizar o padrão mediator

            // conta.MapDelete("{id:int}", (int id, IContaService contaService) =>
            // {
            //     var result = contaService.Delete(id);

            //     return !result.IsSuccess ? Results.NotFound() : Results.NoContent();
            // }).WithName("Exluir Conta").RequireAuthorization();


            // conta.MapPut("mudar-senha/{id:int}", (int id, UpdateSenhaContaInputModel model, IContaService contaService) =>
            // {
            //     var result = contaService.MudarSenha(id, model);

            //     return !result.IsSuccess ? Results.NotFound() : Results.NoContent();
            // }).WithName("Alterar Senha").RequireAuthorization();
            

            conta.MapPut("login", (LoginInputModel model, IContaService contaService) =>
            {
                var result = contaService.Login(model);
                return !result.IsSuccess ? Results.BadRequest(result) : Results.Ok(result);
            }).WithName("Login Conta");
        } 
    }
}