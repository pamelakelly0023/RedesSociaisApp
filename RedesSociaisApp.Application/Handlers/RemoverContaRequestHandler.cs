using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Requests.Conta;
using RedesSociaisApp.Domain.Repositories;

namespace RedesSociaisApp.Application.Handlers
{
    public class RemoverContaRequestHandler : IRequestHandler<RemoverContaRequest, ResultViewModel>
    {
        private readonly IContaRepository _contaRepository;
        public RemoverContaRequestHandler(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }
        public async Task<ResultViewModel> Handle(RemoverContaRequest request, CancellationToken cancellationToken)
        {
            var conta = _contaRepository.GetById(request.ContaId);

            return conta is null ? ResultViewModel.Error("Not Found") : ResultViewModel.Success();
        }
    }
}