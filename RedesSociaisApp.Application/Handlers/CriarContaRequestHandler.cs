using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OperationResult;
using RedesSociaisApp.Application.Requests;
using RedesSociaisApp.Application.Services;
using RedesSociaisApp.Domain.Entities;
using RedesSociaisApp.Domain.Repositories;
using RedesSociaisApp.Infrastructure.Auth;

namespace RedesSociaisApp.Application.Handlers
{
    public class CriarContaRequestHandler : IRequestHandler<CriarContaRequest, int>
    {
        private readonly IContaRepository _contaRepository;

        public CriarContaRequestHandler(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
            
        }
        public async Task<int> Handle(CriarContaRequest request, CancellationToken cancellationToken)
        {
            var conta = request.ToEntity();

            var id = await _contaRepository.Insert(conta);

            return id;
           
        }
    }
}