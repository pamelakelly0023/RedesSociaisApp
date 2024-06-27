using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedesSociaisApp.Domain.Entities;

namespace RedesSociaisApp.Domain.Repositories
{
    public interface IContaRepository
    {
        Conta? GetById(int id);
        Conta? GetByEmailAndPassword(string email, string senha);
        int Insert(Conta conta);
        void Update(Conta conta);
        void Delete(Conta conta);
    }
}