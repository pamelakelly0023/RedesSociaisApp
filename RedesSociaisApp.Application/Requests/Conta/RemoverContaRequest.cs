using MediatR;
using OperationResult;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Responses;

namespace RedesSociaisApp.Application.Requests.Conta
{
    public record RemoverContaRequest(int Id) : IRequest<Result<RemoverContaResponse>>;
   
}