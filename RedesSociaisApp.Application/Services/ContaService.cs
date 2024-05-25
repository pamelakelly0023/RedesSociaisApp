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

        public ResultViewModel Insert(CreateContaInputModel model)
        {
           var conta = new Conta(
                model.NomeCompleto,
                model.Email,
                model.Senha,
                model.DataNasc,
                model.Telefone,
                model.Perfil
           );

           _contaRepository.Insert(conta);

           return ResultViewModel.Success();
        }
    }
}