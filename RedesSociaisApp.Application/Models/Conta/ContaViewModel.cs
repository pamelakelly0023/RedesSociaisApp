using RedesSociaisApp.Domain.Entities;

namespace RedesSociaisApp.Application.Models
{
    public class ContaViewModel
    {
        public ContaViewModel(int id, string nomeCompleto, string role, string email, string perfil, DateTime dataNasc, string telefone)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Role = role;
            Email = email;
            Perfil = perfil;
            DataNasc = dataNasc;
            Telefone = telefone;
        }
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Perfil { get; set; }
        public DateTime DataNasc { get; set; }
        public string Telefone { get; set; }

        public static ContaViewModel FromEntity(Conta entity)
        => new(
            entity.Id,
            entity.NomeCompleto,
            entity.Role,
            entity.Email,
            entity.Perfil.NomeExibicao,
            entity.DataNasc,
            entity.Telefone
        );
    }
}