using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedesSociaisApp.Application.Models;

namespace RedesSociaisApp.Application.Services
{
    public interface IContaService
    {
        ResultViewModel Insert(CreateContaInputModel model);
    }
}