using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OperationResult;
using RedesSociaisApp.Application.Models;
using RedesSociaisApp.Domain.Entities;

namespace RedesSociaisApp.Application.Services
{
    public interface IContaService
    {
        ResultViewModel<LoginViewModel> Login(LoginInputModel model);

    }
}