using API01.Etec.Contracts.Post;
using API01.Etec.Interfaces.Repository;
using API01.Etec.Interfaces.Service;
using API01.Etec.Model;
using API01.Etec.ModelValidators;
using API01.Etec.Validators.BusinessValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API01.Etec.ExtensionMethods;

namespace API01.Etec.Service
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        #region Consulta
        public IEnumerable<ContatoModel> GetAll()
        {
            return _contatoRepository.GetAll().OrderBy(a => a.Nome);
        }

        public ContatoModel GetOne(int id)
        {
            return _contatoRepository.GetOne(id);
        }
        #endregion


        public object Update(ContatoModel contato)
        {
            var validacao = new ContatoModelValidator().Validate(contato);

            if (!validacao.IsValid)
            {
                var erros = validacao.Errors.Select(a => a.ErrorMessage).ToList();
                return erros;
            }

            // busca no banco de dados a entidade atrelada do código
            var contatoDb = _contatoRepository.GetOne(contato.Codigo);
            if (contatoDb == null)
            {
                return new List<string>() { "o código do contato não existe no banco de dados" };
            }

            // business validation
            var businessValidation = new ContatoBusinessValidator(_contatoRepository).Validate(contato);

            if (!businessValidation.IsValid)
            {
                var erros = businessValidation.Errors.Select(a => a.ErrorMessage).ToList();
                return erros;
            }

            return _contatoRepository.Update(contato);

        }
        public object Insert(ContatoPostRequest contatoRequest)
        {
            //var contato = new ContatoModel() { Email = contatoRequest.Email, Nascimento = contatoRequest.Nascimento, Nome = contatoRequest.Nome, Telefone = contatoRequest.Telefone };
            // a linha abaixo substitui criando um ExtensionMethod 
            var contato = contatoRequest.ToContatoModel();

            var validacao = new ContatoModelValidator().Validate(contato);

            if (!validacao.IsValid)
            {
                var erros = validacao.Errors.Select(a => a.ErrorMessage).ToList();
                return erros;
            }

            var businessValidation = new ContatoBusinessValidator(_contatoRepository).Validate(contato);

            if (!businessValidation.IsValid)
            {
                var erros = businessValidation.Errors.Select(a => a.ErrorMessage).ToList();
                return erros;
            }

            return _contatoRepository.Insert(contato);
        }

        public bool Delete(int id)
        {
            var obj = this.GetOne(id);
            if (obj == null)
                return false;

            return _contatoRepository.Delete(obj);
        }

        public ContatoModel GetByEmail(string email)
        {
            return _contatoRepository.GetByEmail(email);
        }

        public IEnumerable<ContatoModel> GetByIdade(int idade)
        {
            return _contatoRepository.GetByIdade(idade);
        }
    }
}
