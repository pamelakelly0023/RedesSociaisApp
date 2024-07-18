using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using OperationResult;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Requests;
using RedesSociaisApp.Domain.Repositories;

namespace RedesSociaisApp.Application.Handlers
{
    public class ObterContaRequestHandler : IRequestHandler<ObterContaRequest, ResultViewModel<ContaViewModel>>
    {
        private readonly IContaRepository _contaRepository;


        public ObterContaRequestHandler(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<ResultViewModel<ContaViewModel>> Handle(ObterContaRequest request, CancellationToken cancellationToken)
        {
            var conta = _contaRepository.GetById(request.Id);

            if( conta is null )
            {
               ResultViewModel.Error("Not Found"); 
            }

            return ResultViewModel<ContaViewModel>.Success(ContaViewModel.FromEntity(conta));
           
        }
    }
}