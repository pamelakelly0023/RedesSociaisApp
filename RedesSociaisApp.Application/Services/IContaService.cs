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
        ResultViewModel Insert(CreateContaInputModel model);
    }
}