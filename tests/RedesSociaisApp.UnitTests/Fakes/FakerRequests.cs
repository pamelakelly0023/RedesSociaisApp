using Bogus;
using RedesSociaisApp.Application.Requests;

namespace RedesSociaisApp.UnitTests.Fakes;

public class FakerRequests 
{
    public static Faker<CriarContaRequest> CriarContaRequest()
     => new Faker<CriarContaRequest>()
     .CustomInstantiator(faker => new CriarContaRequest(
            NomeCompleto: faker.Person.FullName,
            Senha: faker.Internet.Password(),
            Role: "client",
            Email: faker.Person.Email,
            Perfil: CriarPerfilRequest(),
            DataNasc: faker.Date.Recent(),
            Telefone: faker.Person.Phone
     ));

     private static Faker<CriarPerfilRequest> CriarPerfilRequest()
     => new Faker<CriarPerfilRequest>()
     .CustomInstantiator(faker => new CriarPerfilRequest(
            NomeExibicao: faker.Person.FullName,
            Sobre: "descricao",
            Foto: "photo",
            Profissao:"Advogado",
            Localidade: faker.Internet.Locale
     ));
}
