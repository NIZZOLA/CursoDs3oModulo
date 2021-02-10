using API01.Etec.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API01.Etec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        public ICollection<ContatoModel> contatos;

        public ContatoController()
        {
            contatos = new List<ContatoModel>();
            contatos.Add(new ContatoModel() { Codigo = 1, Nome = "KAYLLANY" });
            contatos.Add(new ContatoModel() { Codigo = 2, Nome = "KAYKY" });
            contatos.Add(new ContatoModel() { Codigo = 3, Nome = "BRUNO" });
            contatos.Add(new ContatoModel() { Codigo = 4, Nome = "RODRIGO" });
            contatos.Add(new ContatoModel() { Codigo = 5, Nome = "PEDRO" });
            contatos.Add(new ContatoModel() { Codigo = 6, Nome = "ANTONIO" });
            contatos.Add(new ContatoModel() { Codigo = 7, Nome = "JOÃO" });
        }

        // GET: api/<ContatoController>
        [HttpGet]
        public async Task<ActionResult<ContatoModel>> Get()
        {
            return Ok(contatos.OrderBy(a => a.Nome).ToList());
        }

        // GET api/<ContatoController>/5
        [HttpGet("{id}")]
        public ActionResult<ContatoModel> Get(int id)
        {
            return Ok(contatos.Where(a => a.Codigo == id ).FirstOrDefault() );
        }

        /*
        // GET api/<ContatoController>/5
        [HttpGet("api/nome/{nome}")]
        public ActionResult<ContatoModel> GetByName(string nome)
        {
            return Ok(contatos.Where(a => a.Nome == nome).FirstOrDefault());
        }
        */


        // POST api/<ContatoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ContatoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContatoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
