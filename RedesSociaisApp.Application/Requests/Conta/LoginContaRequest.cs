using MediatR;
using RedesSociaisApp.Application.Models;

namespace RedesSociaisApp.Application.Requests.Conta
{
    public record LoginContaRequest(string Email, string Senha) : IRequest<ResultViewModel<LoginViewModel>>;
}