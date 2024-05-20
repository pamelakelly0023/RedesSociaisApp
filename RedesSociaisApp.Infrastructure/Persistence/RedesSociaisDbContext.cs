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
        public DbSet<Perfil> Perfis{ get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Conta>(e => {
                e.HasKey(p => p.Id);
                e.HasOne(p => p.Perfil)
                    .WithOne(b => b.Conta)
                    .HasForeignKey<Perfil>(p => p.IdConta)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Perfil>(e => {
                e.HasKey(p => p.Id);

                e.HasMany(p => p.Publicacoes)
                    .WithOne(b => b.Perfil)
                    .HasForeignKey(b => b.IdPerfil)
                    .OnDelete(DeleteBehavior.Restrict);
                
                e.HasOne(p => p.Conta)
                    .WithOne(c => c.Perfil)
                    .HasForeignKey<Perfil>(p => p.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);
                
            });

            builder.Entity<Publicacao>(e => {
                e.HasKey(p => p.Id);


            });

            base.OnModelCreating(builder);
        }
    }
}