using FluentValidation;
using RedesSociaisApp.Application.Requests;

namespace RedesSociaisApp.Application.Validators
{
    public class CriarContaValidator : AbstractValidator<CriarContaRequest>
    {
        public CriarContaValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                    .WithMessage("E-mail inválido");

             RuleFor(x => x.NomeCompleto)
                .MaximumLength(100)
                    .WithMessage("Tamanho máximo é de 100 caracteres.");
            
            RuleFor(x => x.NomeCompleto).NotNull().NotEmpty().WithMessage("Campo nome é requerido");

            RuleFor(x => x.Senha).NotEmpty().WithMessage("Senha não pode ser vazio")
                    .MinimumLength(8).WithMessage("O comprimento da sua senha deve ser de pelo menos 8.")
                    .MaximumLength(16).WithMessage("O comprimento da sua senha não deve exceder 16.")
                    .Matches(@"[A-Z]+").WithMessage("Sua senha deve conter pelo menos uma letra maiúscula.")
                    .Matches(@"[a-z]+").WithMessage("Sua senha deve conter pelo menos uma letra minúscula.")
                    .Matches(@"[0-9]+").WithMessage("Sua senha deve conter pelo menos um número.")
                    .Matches(@"[\!\?\*\.]+").WithMessage("Sua senha deve conter pelo menos um (!? *.).");
            
            RuleFor(x => x.Telefone).Matches(@"^[2-9]\d{2}-\d{3}-\d{4}$").WithMessage("Número de telefone inválido");
        }
    }
}