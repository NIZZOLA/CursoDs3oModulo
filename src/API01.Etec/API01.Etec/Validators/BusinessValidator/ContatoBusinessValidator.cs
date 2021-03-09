using API01.Etec.Interfaces.Repository;
using API01.Etec.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API01.Etec.Validators.BusinessValidator
{
    public class ContatoBusinessValidator : AbstractValidator<ContatoModel>
    {
        public ContatoBusinessValidator(IContatoRepository contatoRep)
        {
            RuleFor(cx => cx).Must(entidade => contatoRep.GetByName(entidade.Nome, entidade.Codigo).Count() == 0).WithMessage("O nome não pode ser repetido !");

            RuleFor(a => a).Must(entidade => contatoRep.GetByEmail(entidade.Email, entidade.Codigo ) == null).WithMessage("O E-mail já encontra-se cadastrado !");
        }
    }
}
