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
        public string Email { get; set; }
        public DateTime DataNasc { get; set; }
        public string Telefone { get; set; }
    }
}