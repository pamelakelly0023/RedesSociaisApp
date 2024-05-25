using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedesSociaisApp.Domain.Entities;

namespace RedesSociaisApp.Domain.Repositories
{
    public interface IPublicacaoRepository
    {
        int Add(Publicacao publicacao);
        int Update(Publicacao publicacao);
        void Delete(Publicacao publicacao);
        Publicacao? GetById(int id);
        List<Publicacao> GetAll(int idPerfil);
    }
}