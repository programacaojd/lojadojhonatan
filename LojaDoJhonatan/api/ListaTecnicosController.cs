

using LojaDoJhonatan.dominio;
using LojaDoJhonatan.infraestrutura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaDoJhonatan.api
{
    [ApiController]
    [Route("v1")]
    public class ListaTecnicosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ListaTecnicosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listatecnicos")]
        public async Task<ActionResult<IEnumerable<Tecnico>>> Get()
        {
            var tecnicos = await _context.Tecnicos.ToListAsync();
            return Ok(tecnicos);
        }

        [HttpGet("listatecnicos/buscar")]
        public async Task<ActionResult<IEnumerable<Tecnico>>> BuscarPorNome([FromQuery] string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return BadRequest(new { mensagem = "O nome é obrigatório." });

            var tecnicos = await _context.Tecnicos
                .Where(c => c.Nome.Contains(nome))
                .ToListAsync();

            if (!tecnicos.Any())
                return NotFound(new { mensagem = "Nenhum tecnico encontrado." });

            return Ok(tecnicos);
        }

        [HttpGet("listatecnicos/id")]
        public async Task<ActionResult<IEnumerable<Tecnico>>> BuscarPorid([FromQuery] int id)
        {
            if (id <= 0)
                return BadRequest(new { mensagem = "O id deve ser maior que zero." });

            var tecnicos = await _context.Tecnicos
                .Where(c => c.IdTecnico == id)
                .ToListAsync();

            if (!tecnicos.Any())
                return NotFound(new { mensagem = "Nenhum id encontrado." });

            return Ok(tecnicos);



        }
        
        [HttpGet("listatecnicos/especialidade")]
        public async Task<ActionResult<IEnumerable<Tecnico>>> BuscarPorEspecialidade([FromQuery] string especialidade)
        {
            if (string.IsNullOrWhiteSpace(especialidade))
                return BadRequest(new { mensagem = "A especialidade é obrigatória." });

            var tecnicos = await _context.Tecnicos
                .Where(c => c.Especialidade.Contains(especialidade))
                .ToListAsync();

            if (!tecnicos.Any())
                return NotFound(new { mensagem = "Nenhum especialidade encontrada." });

            return Ok(tecnicos);
        }
    
    }
}
