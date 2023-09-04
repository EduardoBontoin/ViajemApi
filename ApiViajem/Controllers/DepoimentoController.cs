using ApiViajem.Data;
using ApiViajem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ApiViajem.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class DepoimentoController : ControllerBase
    {

        private readonly ViagemContext _context;
        Random rnd = new Random();

       
        public DepoimentoController(ViagemContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaDepoimento ([FromBody]Depoimento depoimento)
        {
            _context.Add(depoimento);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarDepoimentoPorPessoa),new
            {
            nome = depoimento.Nome },depoimento);
        }

        [HttpGet]
        public IEnumerable<Depoimento> BuscarDepoimentos()
        {
            return _context.Depoimentos.ToList();
        }

        [HttpGet("home")]
        public IEnumerable<Depoimento> BuscarDepoimentosAleatorios()
        {
            return _context.Depoimentos.OrderBy(x => Guid.NewGuid()).Take(3).ToList();
        }
        [HttpGet("{nome}")]
        public IActionResult BuscarDepoimentoPorPessoa(string nome)
        {
            
            var depoimento = _context.Depoimentos.FirstOrDefault(x => x.Nome== nome);
            if (depoimento == null || nome == null) return NotFound();
            return Ok(depoimento);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverDepoimento(int id)
        {
            var depoimento = _context.Depoimentos.FirstOrDefault(x => x.Id == id);

            if(depoimento == null) return NotFound();
            _context.Remove(depoimento);
            _context.SaveChanges();
            return NoContent();

        }
    }
}