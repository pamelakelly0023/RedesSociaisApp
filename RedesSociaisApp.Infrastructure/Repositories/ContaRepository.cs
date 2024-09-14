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
        

        public async Task<Conta> Delete(int id)
        {
            var conta = GetById(id);
            if (conta != null)
            {
                _context.Contas.Remove(conta);
                _context.SaveChanges();

                return conta; 
            }

            return null;
        }

        public Conta? GetById(int id)
        {
            var contaId = _context.Contas
            .Include(c => c.Perfil)
            .SingleOrDefault(c => c.Id == id);

            return contaId;
        }  


        public Task<int> Insert(Conta conta)
        {   
            _context.Contas.Add(conta);
            _context.SaveChanges();

            return Task.FromResult(conta.Id);
        }

        public void Update(Conta conta)
        {
            _context.Contas.Update(conta);
            _context.SaveChanges();

        }

    }
}