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

        public bool Delete(ContatoModel contato);

        public IEnumerable<ContatoModel> GetByPartName(string name);

        public IEnumerable<ContatoModel> GetByName(string name);

        public ContatoModel GetByEmail(string email);

        public bool ContactNameExist(int codigo, string name);

        public bool ContactEmailExist(int codigo, string email);
    }
}
