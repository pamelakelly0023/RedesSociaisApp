using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using RedesSociaisApp.Domain.Entities;

namespace RedesSociaisApp.UnitTests.Fakes;

public static class FakerEntities
{
    public static Faker<Conta> CriarConta()
    => new Faker<Conta>()
    .CustomInstantiator(faker => new Conta(
        nomeCompleto: faker.Person.FullName,
        senha: faker.Internet.Password(),
        role: "client",
        email: faker.Person.Email,
        perfil: CriarPerfil(),
        dataNasc: faker.Date.Recent(),
        telefone: faker.Person.Phone
    ));

    public static Faker<Perfil> CriarPerfil()
    => new Faker<Perfil>()
    .CustomInstantiator(faker => new Perfil(
        nomeExibicao: faker.Person.FullName,
        sobre: "descricao",
        foto: "photo",
        profissao:"Advogado",
        localidade: faker.Internet.Locale
    ));
}
