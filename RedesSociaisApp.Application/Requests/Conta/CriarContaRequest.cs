using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore.Query;
using MediatR;
using OperationResult;
using RedesSociaisApp.Domain.Entities;
using SQLitePCL;
using RedesSociaisApp.Application.Models;

namespace RedesSociaisApp.Application.Requests
{
    public record CriarContaRequest(string NomeCompleto, string Senha, string Role, string Email, CriarPerfilRequest Perfil, DateTime DataNasc, string Telefone) : IRequest<ResultViewModel>;
}