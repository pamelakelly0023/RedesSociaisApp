using FluentValidation;
using MediatR;
using RedesSociaisApp.Application.Requests;
using RedesSociaisApp.Application.Validators;
using RedesSociaisApp.Domain.Entities;
using RedesSociaisApp.Domain.Repositories;

namespace RedesSociaisApp.Application.Handlers
{
    public class CriarContaRequestHandler(IContaRepository contaRepository) : IRequestHandler<CriarContaRequest, int>
    {
        private readonly IContaRepository _contaRepository = contaRepository;


        public Task<int> Handle(CriarContaRequest request, CancellationToken cancellationToken)
        {

            var perfil = new Perfil(
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

            _contaRepository.AddAsync(conta);
            //  _contaRepository.SaveChangesAsync(cancellationToken);
          
            return Task.FromResult(conta.Id);
        }
    }
}