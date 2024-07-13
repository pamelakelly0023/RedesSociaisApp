using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Requests.Conta;
using RedesSociaisApp.Domain.Entities;
using RedesSociaisApp.Domain.Repositories;

namespace RedesSociaisApp.Application.Handlers
{
    public class AlterarContaRequestHandler : IRequestHandler<AlterarContaRequest, ResultViewModel>
    {
        private readonly IContaRepository _contaRepository;

        public AlterarContaRequestHandler(IContaRepository contaRepository)
         => _contaRepository = contaRepository; 

        public async Task<ResultViewModel> Handle(AlterarContaRequest request, CancellationToken cancellationToken)
        {
            var conta = _contaRepository.GetById(request.ContaId);

            if(conta is null)
            {
                return ResultViewModel.Error("Not Found");
            }
            
            conta.Update(request.NomeCompleto, request.DataNasc, request.Telefone);

            _contaRepository.Update(conta);

            return ResultViewModel.Success();
           
        }

        // Task<ResultViewModel> IRequestHandler<AlterarContaRequest, ResultViewModel>.Handle(AlterarContaRequest request, CancellationToken cancellationToken)
        // {
        //     throw new NotImplementedException();
        // }
    }
}