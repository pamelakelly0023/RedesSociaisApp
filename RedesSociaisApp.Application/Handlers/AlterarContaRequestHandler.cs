using MediatR;
using OperationResult;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Requests.Conta;
using RedesSociaisApp.Application.Responses;
using RedesSociaisApp.Domain.Repositories;

namespace RedesSociaisApp.Application.Handlers
{
    public class AlterarContaRequestHandler(IContaRepository contaRepository) : IRequestHandler<AlterarContaRequest, Result>
    {
        private readonly IContaRepository _contaRepository = contaRepository;

        public async Task<Result> Handle(AlterarContaRequest request, CancellationToken cancellationToken)
        {
            var conta = await _contaRepository.ObterPorIdAsync(request.Id);

            if(conta is not null) 
            {
                conta.Update(request.NomeCompleto, request.DataNasc, request.Telefone);

                _contaRepository.Atualizar(conta);
                await _contaRepository.SaveChangesAsync();

                return default;
            }
                       
            return default;                  
        }

    }
}