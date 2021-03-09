using API01.Etec.Data;
using API01.Etec.Interfaces.Repository;
using API01.Etec.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API01.Etec.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly API01EtecContext _context;

        public ContatoRepository(API01EtecContext context)
        {
            _context = context;
        }

        public IEnumerable<ContatoModel> GetAll()
        {
            return _context.ContatoModel.ToList();
        }

        public IEnumerable<ContatoModel> GetByIdade(int idade)
        {
            DateTime dataInicial = DateTime.Today.AddYears(-(idade+1));
            DateTime dataFinal = DateTime.Today.AddYears(-(idade));

            return _context.ContatoModel.Where(a => a.Nascimento > dataInicial && a.Nascimento <= dataFinal).ToList();
        }

        public ContatoModel GetOne(int id)
        {
            return _context.ContatoModel.Find(id);
        }

        public ContatoModel Update(ContatoModel contato)
        {
            DetachLocal(a => a.Codigo == contato.Codigo);
            _context.Entry(contato).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
                return this.GetOne(contato.Codigo);
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
        }


        public ContatoModel Insert(ContatoModel contato)
        {
            try
            {
                _context.ContatoModel.Add(contato);
                _context.SaveChangesAsync();
                return contato;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        public bool Delete(ContatoModel contato)
        {
            try
            {
                _context.ContatoModel.Remove(contato);
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<ContatoModel> GetByPartName(string name)
        {
            throw new NotImplementedException();

            IEnumerable<ContatoModel> lista = new List<ContatoModel>();

            ICollection<ContatoModel> lista2 = new List<ContatoModel>();

            IList<ContatoModel> lista4 = new List<ContatoModel>();

            lista = lista4;

            List<ContatoModel> lista3 = new List<ContatoModel>();
        }

        public ContatoModel GetByEmail(string email, int excluirContatoId = 0)
        {
            return _context.ContatoModel.Where(a => a.Email == email && a.Codigo != excluirContatoId ).FirstOrDefault();
        }

        public IEnumerable<ContatoModel> GetByName(string name, int excluirContatoId = 0)
        {
             return _context.ContatoModel.Where(a => a.Nome == name && a.Codigo != excluirContatoId ).ToList();
        }

        public bool ContactNameExist( int codigo, string name )
        {
            var items = _context.ContatoModel.Where(a => a.Nome == name && a.Codigo != codigo ).ToList();
            //a propriedade Any devolve verdadeiro se a lista tiver algum item
            return items.Any();
        }

        public bool ContactEmailExist( int codigo, string email )
        {
            // o retorno sendo uma lista, diferente do item acima, podemos usar direto a propriedade Any
            return _context.ContatoModel.Where(a => a.Email == email && a.Codigo != codigo).Any();
        }

        public void DetachLocal(Func<ContatoModel,bool> predicate)
        {
            var local = _context.Set<ContatoModel>().Local.Where(predicate).FirstOrDefault();
            if(local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
        }

        
    }
}
