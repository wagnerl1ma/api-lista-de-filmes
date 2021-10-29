using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeFilmes.Business.Models.Validations
{
    public class GeneroValidation : AbstractValidator<Genero>
    {
        public GeneroValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
