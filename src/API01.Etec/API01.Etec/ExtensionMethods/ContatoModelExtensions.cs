using API01.Etec.Contracts.Post;
using API01.Etec.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API01.Etec.ExtensionMethods
{
    public static class ContatoModelExtensions
    {
        public static ContatoModel ToContatoModel( this ContatoPostRequest contatoPost )
        {
            var contato = new ContatoModel() { Email = contatoPost.Email, Nascimento = contatoPost.Nascimento, Nome = contatoPost.Nome, Telefone = contatoPost.Telefone };
            return contato;
        }

    }
}
