using API01.Etec.Model;
using API01.Etec.Validators.ValidationHelpers;
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
            RuleFor(c => c.Nome).NotEmpty().WithMessage(ContatoModelErrorMessages.NomeNaoVazio)
                                .MaximumLength(50).WithMessage(ContatoModelErrorMessages.NomeExcedeuTamanhoMaximo);

            RuleFor(c => c.Email).EmailAddress().WithMessage(ContatoModelErrorMessages.EmailInvalido)
                        .MaximumLength(80).WithMessage(ContatoModelErrorMessages.EmailExcedeuTamanhoMaximo);

            RuleFor(c => c.Telefone).MaximumLength(15).WithMessage(ContatoModelErrorMessages.TelefoneExcedeuTamanhoMaximo);

            RuleFor(c => c.Nascimento).NotEmpty().WithMessage(ContatoModelErrorMessages.DataDeNascimentoObrigatória)
                                .LessThan(DateTime.Today).WithMessage(ContatoModelErrorMessages.DataDeNascimentoNaoPodeSerFutura);
        }
    }
}
