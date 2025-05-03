using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using RedesSociaisApp.Application.Requests;
using RedesSociaisApp.Application.Responses;
using RedesSociaisApp.Domain.Entities;
using RedesSociaisApp.Domain.Repositories;

namespace RedesSociaisApp.Application.Handlers
{
    public sealed class CriarContaRequestHandler(IContaRepository contaRepository, ILogger<CriarContaRequest> logger) : IRequestHandler<CriarContaRequest, Result<CriarContaResponse>>
    {
        private readonly IContaRepository _contaRepository = contaRepository;
        private readonly ILogger _logger = logger;

        public async Task<Result<CriarContaResponse>> Handle(CriarContaRequest request, CancellationToken cancellationToken)
        {

            var perfil = new Perfil(
                request.Perfil.NomeExibicao,
                request.Perfil.Sobre,
                request.Perfil.Foto,
                request.Perfil.Profissao,
                request.Perfil.Localidade
            );

            var conta = new Conta(
                request.NomeCompleto,
                request.Senha,
                request.Role,
                request.Email,
                perfil,
                request.DataNasc,
                request.Telefone
            );

            _contaRepository.AddAsync(conta);
            await _contaRepository.SaveChangesAsync();

            _logger.LogInformation("Conta {contaId} criada com sucesso", conta.Id);
  
            return new CriarContaResponse(conta.Id);
    
        }
    }
}