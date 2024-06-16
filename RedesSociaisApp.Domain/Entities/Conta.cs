using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedesSociaisApp.Domain.Entities
{
    public class Conta : BaseEntity
    {
        protected Conta() {}
        public Conta(string nomeCompleto, string senha, string role, string email, Perfil perfil, DateTime dataNasc, string telefone)
            : base()
        {
            NomeCompleto = nomeCompleto;
            Senha = senha;
            Role = role ?? "client";
            Email = email;
            Perfil = perfil;
            DataNasc = dataNasc;
            Telefone = telefone;
        }

        public string NomeCompleto { get; private set; }
        public string Senha { get; private set; }
        public string Role { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNasc { get; private set; }
        public string Telefone { get; private set; }
        public Perfil Perfil{ get; private set; }
        public void Update(string nomeCompleto, DateTime dataNasc, string telefone) 
        {
            NomeCompleto = nomeCompleto;
            DataNasc = dataNasc;
            Telefone = telefone;
        }
        public void MudarSenha(string novaSenha)
        {
            Senha = novaSenha;
        }
    }
}