using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API01.Etec.Validators.ValidationHelpers
{
    public static class ContatoModelErrorMessages
    {
        public static string NomeNaoVazio = "O campo nome não pode ser vazio !";
        public static string NomeExcedeuTamanhoMaximo = "O campo nome não pode ultrapassar {0} caracteres";

        public static string DataDeNascimentoNaoPodeSerFutura = "A data de nascimento não pode ser futura !";
        public static string DataDeNascimentoObrigatória = "A data de nascimento é obrigatória";

        public static string EmailExcedeuTamanhoMaximo = "O campo Email não pode ultrapassar {0} caracteres";
        public static string EmailInvalido = "O campo e-mail não é válido !";

        public static string TelefoneExcedeuTamanhoMaximo = "O Campo do telefone não pode exceder {0} caracteres";

    }
}
