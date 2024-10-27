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
        }
    }
}