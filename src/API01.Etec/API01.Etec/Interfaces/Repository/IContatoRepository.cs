using API01.Etec.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API01.Etec.Interfaces.Repository
{
    public interface IContatoRepository
    {
        public IEnumerable<ContatoModel> GetAll();

        public ContatoModel GetOne(int id);

        public ContatoModel Update(ContatoModel contato);

        public ContatoModel Insert(ContatoModel contato);

        public IEnumerable<ContatoModel> GetByIdade(int idade);

        public bool Delete(ContatoModel contato);

        public IEnumerable<ContatoModel> GetByPartName(string name);

        public IEnumerable<ContatoModel> GetByName(string name, int excluirContatoId = 0);

        public ContatoModel GetByEmail(string email, int excluirContatoId = 0);

        public bool ContactNameExist(int codigo, string name);

        public bool ContactEmailExist(int codigo, string email);
    }
}
