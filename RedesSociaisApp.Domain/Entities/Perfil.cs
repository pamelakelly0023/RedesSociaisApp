using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedesSociaisApp.Domain.Entities
{
    public class Perfil : BaseEntity
    {
        protected Perfil(){}
        public Perfil(string nomeExibicao, string sobre, string foto, string profissao, string localidade)
            : base()
        {
            // IdConta = idConta;
            NomeExibicao = nomeExibicao;
            Sobre = sobre;
            Foto = foto;
            Profissao = profissao;
            Localidade = localidade;
            
            Publicacoes = [];
        }

        public int IdConta { get; private set; }
        public Conta Conta { get; private set; }
        public string NomeExibicao { get; private set; }
        public string Sobre { get; private set; }
        public string Foto { get; private set; }
        public string Profissao { get; private set; }
        public string Localidade { get; private set; }
        public List<Publicacao> Publicacoes { get; private set; }
        public void Update(string nomeExibicao, string sobre, string foto, string profissao, string localidade)
        {
            NomeExibicao = nomeExibicao;
            Sobre = sobre;
            Foto = foto;
            Profissao = profissao;
            Localidade = localidade;
        }
    }
}