using System.Net.Http.Json;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using RedesSociaisApp.Application.Handlers;
using RedesSociaisApp.Application.Requests;
using RedesSociaisApp.Domain.Entities;
using RedesSociaisApp.Domain.Repositories;
using RedesSociaisApp.UnitTests.Fakes;

namespace RedesSociaisApp.UnitTests.Application
{
    public class ContaHandlerTests
    {
        private readonly CriarContaRequestHandler _sut;
        private readonly IMediator _mediator = Substitute.For<IMediator>();
        private readonly IContaRepository _contaRepository = Substitute.For<IContaRepository>();
        private readonly Conta _conta;

        public ContaHandlerTests()
        {
            _sut = new CriarContaRequestHandler(_contaRepository);
        }

        [Fact]
        public async Task PostAction_Deve_CriarContaDoUsuarioComSucesso()
        {

            var request = FakerRequests.CriarContaRequest().Generate();
            await _contaRepository
                .AddAsync(Arg.Any<Conta>());

            // Act
            
            var result = await _sut.Handle(request, CancellationToken.None);

            // Assert

            result.IsSuccess.Should().BeTrue();
           
        }
    }
}