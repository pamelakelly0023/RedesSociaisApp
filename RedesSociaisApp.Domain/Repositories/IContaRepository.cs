using RedesSociaisApp.Domain.Entities;

namespace RedesSociaisApp.Domain.Repositories
{
    public interface IContaRepository
    {
        Conta? GetById(int id);
        // Task<ResultViewModel<Conta>> GetById(int id);
        Conta? GetByEmailAndPassword(string email, string senha);
        Task<int> Insert(Conta conta);
        void Update(Conta conta);
        Task<Conta> Delete(int id);
    }
}