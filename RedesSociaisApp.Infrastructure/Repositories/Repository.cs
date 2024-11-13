using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RedesSociaisApp.Domain.Entities;
using RedesSociaisApp.Domain.Repositories;
using RedesSociaisApp.Infrastructure.Persistence;

namespace RedesSociaisApp.Infrastructure.Repositories;

public class Repository<TEntity> : IRepositoryBase<TEntity>
    where TEntity : BaseEntity
{
    public readonly DbSet<TEntity> _DbSet;
    private readonly RedesSociaisDbContext _context;
    public Repository(RedesSociaisDbContext context) 
    {
        _DbSet = context.Set<TEntity>();
        _context = context;
    } 
        

    public async Task<TEntity> ObterPorIdAsync(int id)
    {
        return await _DbSet.FindAsync(id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await _DbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeletarAsync(TEntity entity)
    {
        _DbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(TEntity entity)
    {
        _DbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
        
}
