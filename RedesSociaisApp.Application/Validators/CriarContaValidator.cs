using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        }
    }
}