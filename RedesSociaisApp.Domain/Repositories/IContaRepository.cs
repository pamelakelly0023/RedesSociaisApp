using RedesSociaisApp.Domain.Entities;

namespace RedesSociaisApp.Domain.Repositories
{
    public interface IContaRepository : IRepositoryBase<Conta>
    {
        Conta? GetByEmailAndPassword(string email, string senha);
    }
}