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
using API01.Etec.Contracts.Post;

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

        // GET: api/Contato2/idade/{idade}
        [HttpGet("idade/{idade}")]
        public ActionResult<IEnumerable<ContatoModel>> GetByIdade(int idade)
        {
            return Ok(_contatoService.GetByIdade(idade));
        }

        // GET: api/Contato2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContatoModel>> GetContatoModel(int id)
        {
            var contatoModel = _contatoService.GetOne(id);

            if (contatoModel == null)
                return NotFound();
            
            return Ok(contatoModel);
        }

        // GET: api/Contato/Email/{email}
        [HttpGet("email/{email}")]
        public async Task<ActionResult<ContatoModel>> GetContatoModelByEmail( string email )
        {
            if (email == "")
                return BadRequest();
            
            var contatoModel = _contatoService.GetByEmail(email);

            if (contatoModel == null)
                return NotFound();

            return Ok(contatoModel);
        }

        // PUT: api/Contato2/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public ActionResult<ContatoModel> PutContatoModel(int id, ContatoModel contatoModel)
        {
            if (id != contatoModel.Codigo)
                return BadRequest();
            
            var response = _contatoService.Update(contatoModel);

            if (response == null)
                return NotFound();
            
            return Ok(response);
        }

        // POST: api/Contato2
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<ContatoModel> PostContatoModel(ContatoPostRequest contatoModel)
        {
            var response = _contatoService.Insert(contatoModel);

            if( response.GetType() != typeof(ContatoModel) )
                return BadRequest(response);
            
            var resposta = (ContatoModel)response;

            return CreatedAtAction("GetContatoModel", new { id = resposta.Codigo }, resposta);
        }

        // DELETE: api/Contato2/5
        [HttpDelete("{id}")]
        public  ActionResult<ContatoModel> DeleteContatoModel(int id)
        {
            var contatoModel = _contatoService.GetOne(id);
            if (contatoModel == null)
                return NotFound();
            
            if (!_contatoService.Delete(id))
                return BadRequest();

            return Ok();
        }

    }
}
