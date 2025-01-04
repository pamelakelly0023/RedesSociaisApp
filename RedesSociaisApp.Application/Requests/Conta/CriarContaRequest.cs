using MediatR;
using OperationResult;
using RedesSociaisApp.Application.Responses;

namespace RedesSociaisApp.Application.Requests;

public record CriarContaRequest(
    string NomeCompleto, 
    string Senha, 
    string Role, 
    string Email, 
    CriarPerfilRequest Perfil, 
    DateTime DataNasc, 
    string Telefone) : IRequest<CriarContaResponse>;
