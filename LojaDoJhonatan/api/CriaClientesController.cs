using LojaDoJhonatan.dominio;
using LojaDoJhonatan.infraestrutura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace LojaDoJhonatan.api
{
    [ApiController]
    [Route("v1")]
    public class CriaClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CriaClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("criaclientes")]
        public async Task<ActionResult<Cliente>> Criar([FromBody] Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return Ok(cliente);
        }

    }
}
