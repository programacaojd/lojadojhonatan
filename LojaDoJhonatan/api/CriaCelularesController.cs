using LojaDoJhonatan.dominio;
using LojaDoJhonatan.infraestrutura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace LojaDoJhonatan.api
{
    [ApiController]
    [Route("v1")]
    public class CriaCelularesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CriaCelularesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("criacelulares")]
        public async Task<ActionResult<Celular>> Criar([FromBody] Celular celular)
        {
            _context.Celulares.Add(celular);
            await _context.SaveChangesAsync();

            return Ok(celular);
        }

    }
}
