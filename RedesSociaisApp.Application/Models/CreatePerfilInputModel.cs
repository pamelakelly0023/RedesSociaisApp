using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedesSociaisApp.Application.Models
{
    public class CreatePerfilInputModel
    {
        public string NomeExibicao { get; set; }
        public string Sobre { get; set; }
        public string Foto { get; set; }
        public string Profissao { get; set; }
        public string Localidade { get; set; }
    }
}