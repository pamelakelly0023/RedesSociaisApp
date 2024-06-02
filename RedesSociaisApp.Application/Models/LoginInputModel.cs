using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedesSociaisApp.Application.Models
{
    public class LoginInputModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    public class LoginViewModel
    {
        public LoginViewModel(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}