using RedesSociaisApp.Domain.Entities;

namespace RedesSociaisApp.Domain.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> ObterPorIdAsync(int id);
    Task AddAsync(TEntity entity);
    Task DeletarAsync(TEntity entity);
    Task Atualizar(TEntity entity);
}
