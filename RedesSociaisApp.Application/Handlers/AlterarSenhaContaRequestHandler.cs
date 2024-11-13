using MediatR;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Requests.Conta;
using RedesSociaisApp.Domain.Repositories;

namespace RedesSociaisApp.Application.Handlers
{
    public class AlterarSenhaContaRequestHandler(IContaRepository contaRepository) : IRequestHandler<AlterarSenhaContaRequest, ResultViewModel>
    {
        private readonly IContaRepository _contaRepository = contaRepository;
 
        public async Task<ResultViewModel> Handle(AlterarSenhaContaRequest request, CancellationToken cancellationToken)
        {
            var conta = await _contaRepository.ObterPorIdAsync(request.Id);

            if(conta != null && conta.Senha == request.Senha)
            {
                conta.MudarSenha(request.NovaSenha);
                await _contaRepository.Atualizar(conta);

                return ResultViewModel.Success();
                
            }
            
           return  ResultViewModel.Error("Not Found");
        }
    }
}