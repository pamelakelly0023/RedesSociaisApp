using MediatR;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Requests;
using RedesSociaisApp.Domain.Repositories;

namespace RedesSociaisApp.Application.Handlers
{
    public class ObterContaRequestHandler(IContaRepository contaRepository) : IRequestHandler<ObterContaRequest, ResultViewModel<ContaViewModel>>
    {
        private readonly IContaRepository _contaRepository = contaRepository;

        public async Task<ResultViewModel<ContaViewModel>> Handle(ObterContaRequest request, CancellationToken cancellationToken)
        {
            var conta = await _contaRepository.ObterPorIdAsync(request.Id);
            if( conta is null )
            {
               ResultViewModel.Error("Not Found"); 
            }

            return ResultViewModel<ContaViewModel>.Success(ContaViewModel.FromEntity(conta));
        }
    }
}