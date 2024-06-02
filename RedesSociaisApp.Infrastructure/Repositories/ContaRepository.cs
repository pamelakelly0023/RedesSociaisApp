using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public Conta? GetByEmail(string email)
        {
            var conta = _context.Contas
                .SingleOrDefault(c => c.Email == email);

            return conta;
        }

        public void Delete(Conta conta)
        {
            _context.Contas.Remove(conta);
            _context.SaveChanges(); 
        }

        public Conta? GetById(int id)
        {
            var conta = _context.Contas
                .SingleOrDefault(c => c.Id == id);

            return conta;
        }

        public int Insert(Conta conta)
        {
            _context.Contas.Add(conta);
            _context.SaveChanges();

            return conta.Id;
        }

        public void Update(Conta conta)
        {
            _context.Contas.Update(conta);
            _context.SaveChanges();
        }
    }
}