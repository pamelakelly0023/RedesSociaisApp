using MediatR;
using RedesSociaisApp.Application.Models;

namespace RedesSociaisApp.Application.Requests.Conta
{
    public record RemoverContaRequest(int Id) : IRequest<ResultViewModel>;
}