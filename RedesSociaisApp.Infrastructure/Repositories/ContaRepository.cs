using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedesSociaisApp.Domain.Entities;
using RedesSociaisApp.Domain.Repositories;
using RedesSociaisApp.Infrastructure.Persistence;

namespace RedesSociaisApp.Infrastructure.Repositories
{
    public class ContaRepository(RedesSociaisDbContext context) : IContaRepository
    {
        private readonly RedesSociaisDbContext _context = context;

        public void AddPerfil(Perfil perfil)
        {
            throw new NotImplementedException();
        }

        public void Delete(Conta conta)
        {
            throw new NotImplementedException();
        }

        public Conta? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Conta conta)
        {
            _context.Contas.Add(conta);
            _context.SaveChanges();
        }

        public void Update(Conta conta)
        {
            throw new NotImplementedException();
        }
    }
}