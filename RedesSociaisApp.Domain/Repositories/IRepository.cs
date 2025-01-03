using System.Xml.XPath;
using RedesSociaisApp.Domain.Entities;

namespace RedesSociaisApp.Domain.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> ObterPorIdAsync(int id);
    int AddAsync(TEntity entity);
    Task DeletarAsync(TEntity entity);
    Task Atualizar(TEntity entity);

    void Add(TEntity entity);
    Task<int> SaveChangesAsync();
}
