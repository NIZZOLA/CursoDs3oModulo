using API01.Etec.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API01.Etec.ModelValidators
{
    public class ContatoModelValidator : AbstractValidator<ContatoModel>
    {
        public ContatoModelValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().WithMessage("O campo nome não pode ser vazio !")
                                .MaximumLength(100).WithMessage("O campo nome não pode ultrapassar 100 caracteres");

            RuleFor(c => c.Email).EmailAddress().WithMessage("O campo e-mail não é válido !");
        }
    }
}
