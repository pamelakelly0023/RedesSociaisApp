using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedesSociaisApp.Domain.Entities;
using RedesSociaisApp.Domain.ResponseModel;

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