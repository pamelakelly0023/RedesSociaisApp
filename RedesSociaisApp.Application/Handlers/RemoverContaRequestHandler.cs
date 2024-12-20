using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using RedesSociaisApp.Application.Exceptions;
using RedesSociaisApp.Application.Requests.Conta;
using RedesSociaisApp.Domain.Repositories;

namespace RedesSociaisApp.Application.Handlers
{
    public class RemoverContaRequestHandler(IContaRepository contaRepository) : IRequestHandler<RemoverContaRequest>
    {
        private readonly IContaRepository _contaRepository = contaRepository;
        public async Task Handle(RemoverContaRequest request, CancellationToken cancellationToken)
        {
            var conta = await _contaRepository.ObterPorIdAsync(request.Id);

            if(conta is null) return;

            await _contaRepository.DeletarAsync(conta);   
           
        }
    }
}