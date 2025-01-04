using MediatR;
using OperationResult;

namespace RedesSociaisApp.Application.Requests
{
    public record CriarPerfilRequest(string NomeExibicao, string Sobre, string Foto, string Profissao, string Localidade);
}