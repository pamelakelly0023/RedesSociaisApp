using MediatR;
using Microsoft.AspNetCore.Http;
using OperationResult;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Validators;

namespace RedesSociaisApp.Application.Requests.Conta
{
    public record LoginContaRequest(string Email, string Senha) : IRequest<Result<LoginViewModel>>;
}