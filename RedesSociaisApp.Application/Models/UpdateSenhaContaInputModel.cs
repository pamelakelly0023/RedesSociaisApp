using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedesSociaisApp.Application.Models
{
    public class UpdateSenhaContaInputModel
    {
        public required string Senha {get; set;}
        public required string NovaSenha {get; set;}
    }
}