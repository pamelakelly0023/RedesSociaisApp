using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedesSociaisApp.Domain.Entities;

namespace RedesSociaisApp.Infrastructure.Persistence
{
    public class RedesSociaisDbContext : DbContext
    {
        public RedesSociaisDbContext(
            DbContextOptions<RedesSociaisDbContext> options)
            : base(options)
        {}

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Perfil> Perfil{ get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }
    }
}