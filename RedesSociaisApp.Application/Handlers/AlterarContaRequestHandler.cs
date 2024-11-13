using MediatR;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Requests.Conta;
using RedesSociaisApp.Domain.Repositories;

namespace RedesSociaisApp.Application.Handlers
{
    public class AlterarContaRequestHandler(IContaRepository contaRepository) : IRequestHandler<AlterarContaRequest, ResultViewModel>
    {
        private readonly IContaRepository _contaRepository = contaRepository;

        public async Task<ResultViewModel> Handle(AlterarContaRequest request, CancellationToken cancellationToken)
        {
            var conta = await _contaRepository.ObterPorIdAsync(request.Id);

            if(conta is null)
            {
                return ResultViewModel.Error("Not Found");
            }

            conta.Update(request.NomeCompleto, request.DataNasc, request.Telefone);

            _contaRepository.Atualizar(conta);

            return ResultViewModel.Success();
           
        }

    }
}