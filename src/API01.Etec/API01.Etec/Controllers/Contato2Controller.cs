using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API01.Etec.Data;
using API01.Etec.Model;

namespace API01.Etec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Contato2Controller : ControllerBase
    {
        private readonly API01EtecContext _context;

        public Contato2Controller(API01EtecContext context)
        {
            _context = context;
        }

        // GET: api/Contato2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContatoModel>>> GetContatoModel()
        {
            return await _context.ContatoModel.ToListAsync();
        }

        // GET: api/Contato2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContatoModel>> GetContatoModel(int id)
        {
            var contatoModel = await _context.ContatoModel.FindAsync(id);

            if (contatoModel == null)
            {
                return NotFound();
            }

            return contatoModel;
        }

        // PUT: api/Contato2/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContatoModel(int id, ContatoModel contatoModel)
        {
            if (id != contatoModel.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(contatoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Contato2
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContatoModel>> PostContatoModel(ContatoModel contatoModel)
        {
            _context.ContatoModel.Add(contatoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContatoModel", new { id = contatoModel.Codigo }, contatoModel);
        }

        // DELETE: api/Contato2/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContatoModel>> DeleteContatoModel(int id)
        {
            var contatoModel = await _context.ContatoModel.FindAsync(id);
            if (contatoModel == null)
            {
                return NotFound();
            }

            _context.ContatoModel.Remove(contatoModel);
            await _context.SaveChangesAsync();

            return contatoModel;
        }

        private bool ContatoModelExists(int id)
        {
            return _context.ContatoModel.Any(e => e.Codigo == id);
        }
    }
}
