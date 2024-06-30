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

namespace RedesSociaisApp.Application.Requests
{
    public class CriarContaRequest : IRequest<int>
    {
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public InputPerfil Perfil { get; set; }
        public DateTime DataNasc { get; set; }
        public string Telefone { get; set; }
        public Conta ToEntity()
        {
            var perfil = new Perfil(
                Perfil.NomeExibicao,
                Perfil.Sobre,
                Perfil.Foto,
                Perfil.Profissao,
                Perfil.Localidade    
            );
            return new Conta(NomeCompleto, 
            Senha, 
            Role, 
            Email, 
            perfil, 
            DataNasc, 
            Telefone);
            
        }
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