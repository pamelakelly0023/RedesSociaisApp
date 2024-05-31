using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedesSociaisApp.Application.Models
{
    public class UpdateContaInputModel
    {
        public string NomeCompleto { get; set; }
        public DateTime DataNasc { get; set; }
        public string Telefone { get; set; }
    }
}