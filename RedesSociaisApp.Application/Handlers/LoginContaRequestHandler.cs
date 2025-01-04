using MediatR;
using Microsoft.AspNetCore.Http;
using OperationResult;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Requests.Conta;
using RedesSociaisApp.Application.Responses;
using RedesSociaisApp.Domain.Repositories;
using RedesSociaisApp.Infrastructure.Auth;

namespace RedesSociaisApp.Application.Handlers
{
    public class LoginContaRequestHandler : IRequestHandler<LoginContaRequest, LoginViewModel>
    {
        private readonly IContaRepository _contaRepository;
        private readonly IAuthService _authService;

        public LoginContaRequestHandler(IContaRepository contaRepository, IAuthService authService)
         {
            _contaRepository = contaRepository;
            _authService = authService;
         }
        public Task<LoginViewModel> Handle(LoginContaRequest request, CancellationToken cancellationToken)
        {
            var conta = _contaRepository.GetByEmailAndPassword(request.Email, request.Senha);
            

            // if(conta is null)
            // {
            //     return Task.FromResult(new LoginViewModel("Dados inválidos"));
            // }     

            var token = _authService.GerarToken(conta.Email, conta.Role);   

            var viewModel = new LoginViewModel(token);
            
            return Task.FromResult(viewModel);

        }
    }
}