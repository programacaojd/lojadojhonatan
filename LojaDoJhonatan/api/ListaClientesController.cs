using LojaDoJhonatan.dominio;
using LojaDoJhonatan.infraestrutura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace LojaDoJhonatan.api
{
    [ApiController]
    [Route("v1")]
    public class ListaClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ListaClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listaclientes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get() 
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes); 
        }

        [HttpGet("listaclientes/buscar")]
        public async Task<ActionResult<IEnumerable<Cliente>>> BuscarPorNome([FromQuery] string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return BadRequest(new { mensagem = "O nome é obrigatório." });

            var clientes = await _context.Clientes
                .Where(c => c.Nome.Contains(nome))
                .ToListAsync();

            if (!clientes.Any())
                return NotFound(new { mensagem = "Nenhum cliente encontrado." });

            return Ok(clientes);
        }

    }


}
