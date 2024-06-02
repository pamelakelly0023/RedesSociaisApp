using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Domain.Entities;

namespace RedesSociaisApp.Application.Services
{
    public interface IContaService
    {
        ResultViewModel<Conta?> GetById(int id);
        ResultViewModel <Conta?> GetByEmail(string email);
        ResultViewModel Insert(CreateContaInputModel model);
        ResultViewModel Update(int id, UpdateContaInputModel model);
        ResultViewModel Delete(int id);
        ResultViewModel MudarSenha(int id, UpdateSenhaContaInputModel model);
        ResultViewModel<LoginViewModel?> Login(LoginInputModel model);
    }
}