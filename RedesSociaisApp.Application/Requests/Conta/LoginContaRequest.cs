using MediatR;
using OperationResult;
using RedesSociaisApp.Application.Models;

namespace RedesSociaisApp.Application.Requests.Conta;
public record LoginContaRequest(string Email, string Senha) : IRequest<Result<LoginViewModel>>;
