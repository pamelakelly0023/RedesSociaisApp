using MediatR;
using RedesSociaisApp.Application.Models;

namespace RedesSociaisApp.Application.Requests.Conta
{
    public record AlterarContaRequest(int Id, string NomeCompleto, DateTime DataNasc, string Telefone) : IRequest<int>;
}