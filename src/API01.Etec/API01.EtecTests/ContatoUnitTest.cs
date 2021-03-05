using API01.Etec.Model;
using API01.Etec.ModelValidators;
using API01.Etec.Validators.ValidationHelpers;
using System;
using System.Linq;
using Xunit;

namespace API01.EtecTests
{
    public class ContatoUnitTest
    {
        private ContatoModel contato;
        public ContatoUnitTest()
        {
            contato = new ContatoModel()
            {
                Codigo = 1,
                Nome = "Jose",
                Email = "marcio@nizzola.com.br",
                Telefone = "(11)99999-8888",
                Nascimento = DateTime.Today.AddYears(-20)
            };
        }

        [Fact]
        public void ObjetoDeveSerValido()
        {
            var validador = new ContatoModelValidator();
            var result = validador.Validate(contato);

            Assert.True(result.IsValid);
        }

        [Theory(DisplayName = "Teste de emails inválidos")]
        [InlineData("aaaaa")]
        [InlineData("aaaaa@")]
        [InlineData("@aaaaa")]
        [InlineData("aaaaa.com")]
        public void EmailNaoDeveSerValido(string email)
        {
            var validador = new ContatoModelValidator();
            contato.Email = email;
            var result = validador.Validate(contato);

            Assert.False(result.IsValid);
            var erros = result.Errors.Select(a => a.ErrorMessage).ToList();
            Assert.True(erros.Contains(ContatoModelErrorMessages.EmailInvalido) == true);
        }

        [Theory(DisplayName = "Teste de datas de nascimento validas")]
        [InlineData("01/01/2020")]
        [InlineData("01/01/1980")]
        public void DataDeveSerValida(string dataStr)
        {
            var validador = new ContatoModelValidator();
            contato.Nascimento = DateTime.Parse(dataStr);
            var result = validador.Validate(contato);

            Assert.True(result.IsValid);
        }

        [Theory(DisplayName = "Teste de datas de nascimento invalidas")]
        [InlineData("01/01/2022")]
        [InlineData("01/01/4400")]
        public void DataDeveSerInValida(string dataStr)
        {
            var validador = new ContatoModelValidator();
            contato.Nascimento = DateTime.Parse(dataStr);
            var result = validador.Validate(contato);

            Assert.False(result.IsValid);
            var erros = result.Errors.Select(a => a.ErrorMessage).ToList();
            Assert.True(erros.Contains(ContatoModelErrorMessages.DataDeNascimentoNaoPodeSerFutura) == true );
            
        }
    }
}
