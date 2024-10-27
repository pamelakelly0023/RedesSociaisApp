using MediatR;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Requests.Conta;
using RedesSociaisApp.Domain.Repositories;

namespace RedesSociaisApp.Application.Handlers
{
    public class AlterarSenhaContaRequestHandler : IRequestHandler<AlterarSenhaContaRequest, ResultViewModel>
    {
        private readonly IContaRepository _contaRepository;

        public AlterarSenhaContaRequestHandler(IContaRepository contaRepository)
         => _contaRepository = contaRepository; 
        public async Task<ResultViewModel> Handle(AlterarSenhaContaRequest request, CancellationToken cancellationToken)
        {
            var conta = _contaRepository.GetById(request.Id);

            if(conta != null && conta.Senha == request.Senha)
            {
                conta.MudarSenha(request.NovaSenha);
                _contaRepository.Update(conta);

                return ResultViewModel.Success();
                
            }
            
           return  ResultViewModel.Error("Not Found");
        }
    }
}