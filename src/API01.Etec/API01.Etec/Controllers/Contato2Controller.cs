using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API01.Etec.Data;
using API01.Etec.Model;
using API01.Etec.Interfaces.Service;

namespace API01.Etec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Contato2Controller : ControllerBase
    {
        private readonly IContatoService _contatoService;


        public Contato2Controller(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        // GET: api/Contato2
        [HttpGet]
        public ActionResult<IEnumerable<ContatoModel>> GetContatoModel()
        {
            return Ok(_contatoService.GetAll());
        }

        // GET: api/Contato2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContatoModel>> GetContatoModel(int id)
        {
            var contatoModel = _contatoService.GetOne(id);

            if (contatoModel == null)
            {
                return NotFound();
            }

            return Ok(contatoModel);
        }

        // PUT: api/Contato2/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public ActionResult<ContatoModel> PutContatoModel(int id, ContatoModel contatoModel)
        {
            if (id != contatoModel.Codigo)
            {
                return BadRequest();
            }

            var response = _contatoService.Update(contatoModel);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        // POST: api/Contato2
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<ContatoModel> PostContatoModel(ContatoModel contatoModel)
        {
            var response = _contatoService.Insert(contatoModel);

            if( response.GetType() != typeof(ContatoModel) )
                return BadRequest(response);

            return CreatedAtAction("GetContatoModel", new { id = contatoModel.Codigo }, contatoModel);
        }

        // DELETE: api/Contato2/5
        [HttpDelete("{id}")]
        public  ActionResult<ContatoModel> DeleteContatoModel(int id)
        {
            var contatoModel = _contatoService.GetOne(id);
            if (contatoModel == null)
            {
                return NotFound();
            }

            if (!_contatoService.Delete(id))
                return BadRequest();

            return Ok();
        }

    }
}
