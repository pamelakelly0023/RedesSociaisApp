using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Domain.Entities;
using RedesSociaisApp.Domain.Repositories;
using RedesSociaisApp.Infrastructure.Auth;

namespace RedesSociaisApp.Application.Services
{
    public class ContaService(IContaRepository contaRepository, IAuthService authService) : IContaService
    {
        private readonly IContaRepository _contaRepository = contaRepository;
        
        private readonly IAuthService _authService = authService ;

        public ResultViewModel Delete(int id)
        {
            var conta = _contaRepository.GetById(id);
            if(conta is null)
            {
                return ResultViewModel.Error("Not Found");
            }

            ///conta.SetAsDeleted();
            _contaRepository.Delete(conta);

            return ResultViewModel.Success();
        }

        public ResultViewModel<Conta?> GetByEmail(string email)
        {
            var conta = _contaRepository.GetByEmail(email);

            return conta is null ?
                ResultViewModel<Conta?>.Error("Not Found") : 
                ResultViewModel<Conta?>.Success(conta);
        }

        public ResultViewModel<Conta?> GetById(int id)
        {
            var conta = _contaRepository.GetById(id);

            return conta is null ?
                ResultViewModel<Conta?>.Error("Not Found") : 
                ResultViewModel<Conta?>.Success(conta);
        }

        public ResultViewModel Insert(CreateContaInputModel model)
        {
           var conta = new Conta(
                model.NomeCompleto,
                model.Senha,
                model.Role,
                model.Email,
                model.DataNasc,
                model.Telefone
           );

           _contaRepository.Insert(conta);

           return ResultViewModel.Success();
        }

        public ResultViewModel<LoginViewModel?> Login(LoginInputModel model)
        {
            var hash = _authService.Hash(model.Senha);
            var conta = _contaRepository.GetByEmail(model.Email);

            if(conta is null || conta.Senha != hash)
            {
                 return ResultViewModel<LoginViewModel?>.Error("Error");
            }     

            var token = _authService.GerarToken(conta.Email, conta.Role);   

            var viewModel = new LoginViewModel(token);
            
            return ResultViewModel<LoginViewModel?>.Success(viewModel);
        }

        public ResultViewModel MudarSenha(int id, UpdateSenhaContaInputModel model)
        {
            var conta = _contaRepository.GetById(id);

            if(conta != null && conta.Senha == model.Senha)
            {
                conta.MudarSenha(model.NovaSenha);
                _contaRepository.Update(conta);

                return ResultViewModel.Success();
                
            }
            
           return  ResultViewModel.Error("Not Found");
            
        }

        public ResultViewModel Update(int id, UpdateContaInputModel model)
        {
            var conta = _contaRepository.GetById(id);

            if(conta is null)
            {
                return  ResultViewModel.Error("Not Found");
            }

            conta.Update(model.NomeCompleto, model.DataNasc, model.Telefone);
            _contaRepository.Update(conta);

            return ResultViewModel.Success();

        }
    }
}