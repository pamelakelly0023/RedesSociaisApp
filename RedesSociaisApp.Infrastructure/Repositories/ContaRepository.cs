using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedesSociaisApp.Domain.Entities;
using RedesSociaisApp.Domain.Repositories;
using RedesSociaisApp.Infrastructure.Persistence;

namespace RedesSociaisApp.Infrastructure.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly RedesSociaisDbContext _context;
        public ContaRepository(RedesSociaisDbContext context) => _context = context;


        public Conta? GetByEmailAndPassword(string email, string senha)
            => _context.Contas.FirstOrDefault(c => c.Email == email && c.Senha == senha);                     
        

        public void Delete(Conta conta)
        {
            _context.Contas.Remove(conta);
            _context.SaveChanges(); 
        }

        public Conta? GetById(int id)
        => _context.Contas
            .Include(c => c.Perfil)
            .SingleOrDefault(c => c.Id == id);


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