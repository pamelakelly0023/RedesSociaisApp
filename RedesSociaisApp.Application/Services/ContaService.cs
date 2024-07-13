using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Domain.Entities;
using RedesSociaisApp.Domain.Repositories;
using RedesSociaisApp.Infrastructure.Auth;
using RedesSociaisApp.Infrastructure.Persistence;

namespace RedesSociaisApp.Application.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;
        
        private readonly IAuthService _authService;

        public ContaService(IContaRepository contaRepository, IAuthService authService)
        {
            _contaRepository = contaRepository;
            _authService = authService;
        }

        // Migrar os seguintes serviços para se adequar a implementação do padrão mediator

        public ResultViewModel<LoginViewModel?> Login(LoginInputModel model)
        {
            var conta = _contaRepository.GetByEmailAndPassword(model.Email, model.Senha);
            

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