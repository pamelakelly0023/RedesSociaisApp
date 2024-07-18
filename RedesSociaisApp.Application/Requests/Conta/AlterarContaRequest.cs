using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RedesSociaisApp.Application.Models;

namespace RedesSociaisApp.Application.Requests.Conta
{
    public record AlterarContaRequest(int Id, string NomeCompleto, DateTime DataNasc, string Telefone) : IRequest<ResultViewModel>;
}