using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedesSociaisApp.Domain.Entities;

namespace RedesSociaisApp.Application.Models
{
    public class CreateContaInputModel
    {
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public PerfilInputModel Perfil { get; set; }
        public DateTime DataNasc { get; set; }
        public string Telefone { get; set; }
    }

    public class PerfilInputModel
    {
        public string NomeExibicao { get; set; }
        public string Sobre { get; set; }
        public string Foto { get; set; }
        public string Profissao { get; set; }
        public string Localidade { get; set; }
    }
}