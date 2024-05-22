using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedesSociaisApp.Domain.Entities
{
    public class Publicacao : BaseEntity
    {
        protected Publicacao(){}
        public Publicacao(int idPerfil, string conteudo, DateTime dataPublicacao, string? localidade, Perfil perfil)
            : base()
        {
            IdPerfil = idPerfil;
            Perfil = perfil;
            Conteudo = conteudo;
            DataPublicacao = dataPublicacao;
            Localidade = localidade;
            Perfil = perfil;
        }

        public int IdPerfil { get; private set; }
        public Perfil Perfil { get; private set; }
        public string Conteudo { get; private set; }
        public DateTime DataPublicacao { get; private set; }
        public string? Localidade { get; private set; }
    }
}