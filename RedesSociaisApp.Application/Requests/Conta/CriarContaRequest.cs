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
    public class CriarContaRequest : IRequest<ResultViewModel>
    {
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public InputPerfil Perfil { get; set; }
        public DateTime DataNasc { get; set; }
        public string Telefone { get; set; }
    }

    public class InputPerfil
    {
        public string NomeExibicao { get; set; }
        public string Sobre { get; set; }
        public string Foto { get; set; }
        public string Profissao { get; set; }
        public string Localidade { get; set; }

    }
}