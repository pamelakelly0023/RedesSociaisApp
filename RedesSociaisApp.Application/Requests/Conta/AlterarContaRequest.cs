using MediatR;
using OperationResult;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Responses;

namespace RedesSociaisApp.Application.Requests.Conta;
public record AlterarContaRequest(int Id, string NomeCompleto, DateTime DataNasc, string Telefone) : IRequest<Result>;
