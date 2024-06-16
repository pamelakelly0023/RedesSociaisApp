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

        public ResultViewModel Delete(int id)
        {
            var conta = _contaRepository.GetById(id);
            if(conta is null)
            {
                return ResultViewModel.Error("Not Found");
            }

            //conta.SetAsDeleted();
            _contaRepository.Delete(conta);

            return ResultViewModel.Success();
        }

        public ResultViewModel<Conta?> GetById(int id)
        {
            var conta = _contaRepository.GetById(id);

            return conta is null ?
                ResultViewModel<Conta?>.Error("Not Found") : 
                ResultViewModel<Conta?>.Success(conta);
        }

        public ResultViewModel<int> Insert(int id, CreateContaInputModel model)
        {
            var perfil = new Perfil(
                id,
                model.Perfil.NomeExibicao,
                model.Perfil.Sobre,
                model.Perfil.Foto,
                model.Perfil.Profissao,
                model.Perfil.Localidade    
            );

            var conta = new Conta(
                model.NomeCompleto,
                model.Senha,
                model.Role,
                model.Email,
                perfil,
                model.DataNasc,
                model.Telefone
           );

           _contaRepository.Insert(conta);

           return ResultViewModel<int>.Success(conta.Id);
        }


        public ResultViewModel<LoginViewModel?> Login(LoginInputModel model)
        {
            var hash = _authService.Hash(model.Senha);
            var conta = _contaRepository.GetByEmailAndPassword(model.Email, model.Senha);
            

            if(conta is null )
            {
                 return ResultViewModel<LoginViewModel?>.Error("Erro ao validar os dados");
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

        public ResultViewModel Perfil(int id, CreatePerfilInputModel model)
        {
            var conta = _contaRepository.GetById(id);

            if(conta is null)
            {
                return ResultViewModel.Error("Not found");
            }

            var perfil = new Perfil(
                id,
                model.NomeExibicao,
                model.Sobre,
                model.Foto,
                model.Profissao,
                model.Localidade    
            );

            _contaRepository.AddPerfil(perfil);

            return ResultViewModel.Success();
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