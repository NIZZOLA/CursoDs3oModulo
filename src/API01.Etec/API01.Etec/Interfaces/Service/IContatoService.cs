using API01.Etec.Contracts.Post;
using API01.Etec.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API01.Etec.Interfaces.Service
{
    public interface IContatoService
    {
        public IEnumerable<ContatoModel> GetAll();
        public ContatoModel GetOne(int id);
        public object Update(ContatoModel contato);
        public object Insert(ContatoPostRequest contato);

        public bool Delete(int id);
    }
}
