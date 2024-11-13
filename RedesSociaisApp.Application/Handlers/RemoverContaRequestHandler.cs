using MediatR;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Requests.Conta;
using RedesSociaisApp.Domain.Repositories;

namespace RedesSociaisApp.Application.Handlers
{
    public class RemoverContaRequestHandler(IContaRepository contaRepository) : IRequestHandler<RemoverContaRequest, ResultViewModel>
    {
        private readonly IContaRepository _contaRepository = contaRepository;
        public async Task<ResultViewModel> Handle(RemoverContaRequest request, CancellationToken cancellationToken)
        {
            var conta = await _contaRepository.ObterPorIdAsync(request.Id);
            if (conta is null)
            {
                ResultViewModel.Error("Not Found");
            }
            
            await _contaRepository.DeletarAsync(conta);

            return ResultViewModel.Success();
        }
    }
}