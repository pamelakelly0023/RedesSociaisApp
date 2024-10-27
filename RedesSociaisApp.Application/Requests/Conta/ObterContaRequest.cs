using MediatR;
using RedesSociaisApp.Application.Models;

namespace RedesSociaisApp.Application.Requests
{
    public record ObterContaRequest(int Id) : IRequest<ResultViewModel<ContaViewModel>>;
}