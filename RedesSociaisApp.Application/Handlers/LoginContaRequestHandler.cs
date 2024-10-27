using MediatR;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Requests.Conta;
using RedesSociaisApp.Domain.Repositories;
using RedesSociaisApp.Infrastructure.Auth;

namespace RedesSociaisApp.Application.Handlers
{
    public class LoginContaRequestHandler : IRequestHandler<LoginContaRequest, ResultViewModel<LoginViewModel>>
    {
        private readonly IContaRepository _contaRepository;
        private readonly IAuthService _authService;

        public LoginContaRequestHandler(IContaRepository contaRepository, IAuthService authService)
         {
            _contaRepository = contaRepository;
            _authService = authService;
         }
        public async Task<ResultViewModel<LoginViewModel>> Handle(LoginContaRequest request, CancellationToken cancellationToken)
        {
            var conta = _contaRepository.GetByEmailAndPassword(request.Email, request.Senha);
            

            if(conta is null)
            {
                 return ResultViewModel<LoginViewModel?>.Error("Erro ao validar os dados");
            }     

            var token = _authService.GerarToken(conta.Email, conta.Role);   

            var viewModel = new LoginViewModel(token);

            return ResultViewModel<LoginViewModel?>.Success(viewModel);
        }
    }
}