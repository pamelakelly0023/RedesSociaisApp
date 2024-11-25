using NSubstitute;
using RedesSociaisApp.Application.Handlers;
using RedesSociaisApp.Domain.Entities;
using RedesSociaisApp.Domain.Repositories;
using RedesSociaisApp.UnitTests.Fakes;

namespace RedesSociaisApp.UnitTests.Application
{
    public class CriarContaRequestHandlerTests
    {
        private readonly CriarContaRequestHandler _sut;
        private readonly IContaRepository _contaRepository = Substitute.For<IContaRepository>();
        private readonly Conta _conta;

        public CriarContaRequestHandlerTests()
        {
            _sut = new CriarContaRequestHandler(_contaRepository);
        }

        [Fact]
        public async Task PostAction_Deve_CriarContaDoUsuarioComSucesso()
        {
            //Arrange

            var request = FakerRequests.CriarContaRequest().Generate();
            
            //Act
            var result = ((MediatR.IRequestHandler<RedesSociaisApp.Application.Requests.CriarContaRequest, OperationResult.Result>)_sut).Handle(request, CancellationToken.None);

            //Assert
            _contaRepository.Received().AddAsync(Arg.Any<Conta>());

            Assert.True(result.IsSuccess);   
        }
    }
}