using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedesSociaisApp.Domain.Entities;

namespace RedesSociaisApp.Domain.Repositories
{
    public interface IPerfilRepository
    {
        void Update (Perfil perfil);
        void Delete (Perfil perfil);
        Perfil? GetById(int id);
        void addPublicacao(Publicacao publicacao);
    }
}