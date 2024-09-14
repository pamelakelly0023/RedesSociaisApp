using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedesSociaisApp.Application.Auth
{
    public interface IAuthService
    {
        string Hash(string senha);
        string GerarToken(string email, string role);
    }
}