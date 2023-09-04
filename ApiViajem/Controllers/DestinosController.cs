using ApiViajem.Data;
using ApiViajem.Models;
using ApiViajem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiViajem.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class DestinosController : ControllerBase
    {
        private  ViagemContext _context;
        public GptService _gptService;
        public DestinosController(ViagemContext context,GptService gptService)
            
        {
            _context = context;
            _gptService = gptService;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaDestino([FromBody]Destino destino)
        {
            if (destino.Descritivo is null)
            {
                destino.Descritivo = await _gptService.ComunicaComGpt(destino.Nome);
            }
            _context.Add(destino);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RetornarDestinoFiltrado), new
            {
                id = destino.Id
            }, destino);
        }

        [HttpGet()]
        public ICollection<Destino> RetornarDestino(int id)
        {


            return _context.Destinos.ToList();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetornarDestinoFiltrado(int id)
        {
            if (id != 0) return BadRequest("'Nome' Não pode ser nulo");

            var resultado = await _context.Destinos.FirstOrDefaultAsync(x => x.Id == id);

            if (resultado is null) return NotFound("Não foram encontrados nenhum destino com a busca");

            return Ok(resultado);

        }



        [HttpDelete("{id}")]
        public IActionResult RemoverDestino(int id)
        {
            var resultado = _context.Destinos.FirstOrDefault(x => x.Id == id);
            if (resultado is null) return NotFound("Falha ao encontrar comentario");
            _context.Remove(resultado);
            _context.SaveChanges();
            return Ok($"o Comentario {resultado.Nome} foi excluido com sucesso");
        }
    }
}
