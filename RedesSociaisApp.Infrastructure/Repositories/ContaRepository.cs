using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedesSociaisApp.Domain;
using RedesSociaisApp.Domain.Entities;
using RedesSociaisApp.Domain.Repositories;
using RedesSociaisApp.Infrastructure.Persistence;

namespace RedesSociaisApp.Infrastructure.Repositories
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(RedesSociaisDbContext context) : base(context)
        {
        }

        public Conta? GetByEmailAndPassword(string email, string senha)
            => _context.Contas.FirstOrDefault(c => c.Email == email && c.Senha == senha);                      
    }
}