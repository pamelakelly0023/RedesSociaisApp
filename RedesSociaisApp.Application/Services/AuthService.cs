using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace RedesSociaisApp.Application.Auth
{
    public class AuthService(IConfiguration configuration) : IAuthService
    {
        private readonly IConfiguration _configuration = configuration;
        public string GerarToken(string email, string role)
        {

            var issuer = _configuration["JWT:Issuer"];
            var audience = _configuration["JWT:Audience"];

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:Key"])
            );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("userName", email),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken
            (
                issuer: issuer,
                audience: audience,
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: credentials,
                claims: claims
            );

            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }

        public string Hash(string senha)
        {
             using (var hash = SHA256.Create())
            {
                var bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(senha));
                
                // Concatenação de vários items
                var builder = new StringBuilder();

                for (var i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                } 

                return builder.ToString();
            }
        }

    }
}