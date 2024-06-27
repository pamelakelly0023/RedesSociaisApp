using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Services;

namespace RedesSociaisApp.API.Endpoints
{
    public static class ContaEndpoint
    {
        public static void MapContaEndpoint(this IEndpointRouteBuilder app)
        {
            var conta = app.MapGroup("/api/v1/conta");

            conta.MapGet("{id}", (int id, IContaService contaService) =>
            {
                var result = contaService.GetById(id);

                    if(!result.IsSuccess)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(result);
            }).WithName("Detalhes Conta").RequireAuthorization();


            conta.MapPost(string.Empty, (CreateContaInputModel model, IContaService contaService) =>
            {
                var result = contaService.Insert(model);

                return Results.CreatedAtRoute("Detalhes Conta", new { id = result});
            }).WithName("Cadastrar Conta");


            conta.MapPut("{id:int}", (int id, UpdateContaInputModel model, IContaService contaService) =>
            {
                var result = contaService.Update(id, model);

                return !result.IsSuccess ? Results.NotFound() : Results.NoContent();
            }).WithName("Alterar Conta").RequireAuthorization();


            conta.MapDelete("{id:int}", (int id, IContaService contaService) =>
            {
                var result = contaService.Delete(id);

                return !result.IsSuccess ? Results.NotFound() : Results.NoContent();
            }).WithName("Exluir Conta").RequireAuthorization();


            conta.MapPut("mudar-senha/{id:int}", (int id, UpdateSenhaContaInputModel model, IContaService contaService) =>
            {
                var result = contaService.MudarSenha(id, model);

                return !result.IsSuccess ? Results.NotFound() : Results.NoContent();
            }).WithName("Alterar Senha").RequireAuthorization();
            

            conta.MapPut("login", (LoginInputModel model, IContaService contaService) =>
            {
                var result = contaService.Login(model);
                return !result.IsSuccess ? Results.BadRequest(result) : Results.Ok(result);
            }).WithName("Login Conta");
        } 
    }
}