using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API01.Etec.Contracts.Post
{
    public class ContatoPostRequest
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public DateTime Nascimento { get; set; }
    }
}
