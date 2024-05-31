using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Domain.Entities;
using RedesSociaisApp.Domain.Repositories;

namespace RedesSociaisApp.Application.Services
{
    public class ContaService(IContaRepository contaRepository) : IContaService
    {
        private readonly IContaRepository _contaRepository = contaRepository;

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
                model.Email,
                model.DataNasc,
                model.Telefone
           );

           _contaRepository.Insert(conta);

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