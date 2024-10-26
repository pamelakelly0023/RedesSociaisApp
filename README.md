# Projeto Web API "Redes Sociais"

> :construction: Projeto em construção :construction:

## Descrição

Este projeto visa desenvolver uma Web API para uma plataforma de redes sociais, permitindo a interação entre usuários por meio de funcionalidades essenciais, como criação de contas, perfis, publicações e feed de notícias.

## Funcionalidades

- **Criação de Conta**: Permite que novos usuários se registrem na plataforma.
- **Gerenciamento de Perfil**: Os usuários podem criar, editar e excluir seus perfis.
- **Publicações**: Criar, editar e excluir publicações.
- **Feed de Notícias**: Exibe as publicações mais relevantes dos amigos e seguidores.
- **Autenticação**: Sistema de login seguro utilizando JWT.
- **Interação Social**: Usuários podem seguir, curtir e comentar em publicações.

## Arquitetura


- **API**: Camada responsável pelo código de interface com outros componentes externos, como usuários ou aplicações.
- **Application**: Camada responsável pela implementação de casos de uso, serviços de aplicação, DTOs, Requests e Handlers.
- **Domain**: Contém as entidades e interfaces principais do domínio.
- **Infrastructure**: Camada responsável por integração com componentes de infraestrutura, como repositórios e acesso a dados.


## Tecnologias e Padrões Utilizados

- .NET 8
- Entity Framework Core(ORM)
- MySql
- JWT para autenticação
- Padrão Repository
- Swagger para documentação
- xUnit
- Padrão Mediator 

## Instruções

1. Clone este repositório:
   ```bash
   git clone https://github.com/pamelakelly0023/RedesSociaisApp.git

2. Navegue até a pasta do projeto:
   ```bash
    cd RedesSociaisApp

3. Restaure os pacotes do NuGet:
    ```base
    dotnet restore

4. Configure a string de conexão no arquivo appsettings.json:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=seu-servidor;Database=nome-do-banco;User Id=seu-usuario;Password=sua-senha;"
    }

5. Execute as migrações do banco de dados:
    ```bash
    dotnet ef database update

6. Inicie a aplicação:
    ```bash
    cd RedesSociaisApp/RedesSociaisApp.API
    dotnet run  