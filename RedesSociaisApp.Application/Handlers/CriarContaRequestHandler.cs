using MediatR;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Application.Requests;
using RedesSociaisApp.Domain.Entities;
using RedesSociaisApp.Domain.Repositories;

namespace RedesSociaisApp.Application.Handlers
{
    public class CriarContaRequestHandler(IContaRepository contaRepository) : IRequestHandler<CriarContaRequest, ResultViewModel>
    {
        private readonly IContaRepository _contaRepository = contaRepository;

        public async Task<ResultViewModel> Handle(CriarContaRequest request, CancellationToken cancellationToken)
        {

            var perfil = new Perfil (
                request.Perfil.NomeExibicao,
                request.Perfil.Sobre,
                request.Perfil.Foto,
                request.Perfil.Profissao,
                request.Perfil.Localidade 
            );

            var conta = new Conta(
                request.NomeCompleto,
                request.Senha,
                request.Role,
                request.Email,
                perfil,
                request.DataNasc,
                request.Telefone
            );    

            await _contaRepository.AddAsync(conta);

            return ResultViewModel.Success();
           
        }
    }
}