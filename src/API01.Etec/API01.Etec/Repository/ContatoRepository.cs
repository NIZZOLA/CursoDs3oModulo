using API01.Etec.Data;
using API01.Etec.Interfaces.Repository;
using API01.Etec.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace API01.Etec.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly API01EtecContext _context;
        private readonly ILogger _logger;

        public ContatoRepository(API01EtecContext context, ILoggerFactory logger)
        {
            _context = context;
            _logger = logger.CreateLogger("ContatoRepository");
        }

        public IEnumerable<ContatoModel> GetAll()
        {
            try
            {
                return _context.ContatoModel.ToList();
            }
            catch (Exception)
            {
                _logger.LogError(DateTime.Now.ToString() + "- Falha na consulta");
                return null;
            }

        }

        public ContatoModel GetOne(int id)
        {
            return _context.ContatoModel.Find(id);
        }

        public ContatoModel Update(ContatoModel contato)
        {
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
                _logger.LogError(DateTime.Now.ToString() + "- Erro no Post - " + error.Message.ToString() + " " + JsonSerializer.Serialize(contato));

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
        }
    }
}
