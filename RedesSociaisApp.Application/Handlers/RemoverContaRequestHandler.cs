using MediatR;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Requests.Conta;
using RedesSociaisApp.Domain.Repositories;

namespace RedesSociaisApp.Application.Handlers
{
    public class RemoverContaRequestHandler : IRequestHandler<RemoverContaRequest, ResultViewModel>
    {
        private readonly IContaRepository _contaRepository;
        public RemoverContaRequestHandler(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }
        public async Task<ResultViewModel> Handle(RemoverContaRequest request, CancellationToken cancellationToken)
        {
            var conta = _contaRepository.GetById(request.Id);
            if (conta is null)
            {
                ResultViewModel.Error("Not Found");
            }
            
            await _contaRepository.Delete(conta.Id);
            return ResultViewModel.Success();
        }
    }
}