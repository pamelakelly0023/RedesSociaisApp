using MediatR;
using RedesSociaisApp.Application.Models;

namespace RedesSociaisApp.Application.Requests.Conta
{
    public record AlterarSenhaContaRequest(int Id, string Senha, string NovaSenha) : IRequest<ResultViewModel>;
}