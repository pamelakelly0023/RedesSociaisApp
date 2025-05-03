using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using RedesSociaisApp.Application.Exceptions;
using RedesSociaisApp.Application.Requests.Conta;
using RedesSociaisApp.Application.Responses;
using RedesSociaisApp.Domain.Repositories;

namespace RedesSociaisApp.Application.Handlers
{
    public class RemoverContaRequestHandler(IContaRepository contaRepository) : IRequestHandler<RemoverContaRequest, Result<RemoverContaResponse>>
    {
        private readonly IContaRepository _contaRepository = contaRepository;
        public async Task<Result<RemoverContaResponse>> Handle(RemoverContaRequest request, CancellationToken cancellationToken)
        {
            var conta = await _contaRepository.ObterPorIdAsync(request.Id);

            if(conta is not null) 
                await _contaRepository.DeletarAsync(conta);

            return default;
           
        }
    }
}