using LojaDoJhonatan.dominio;
using LojaDoJhonatan.infraestrutura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace LojaDoJhonatan.api
{
    [ApiController]
    [Route("v1")]
    public class CriaTecnicosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CriaTecnicosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("criatecnicos")]
        public async Task<ActionResult<Tecnico>> Criar([FromBody] Tecnico tecnico)
        {
            _context.Tecnicos.Add(tecnico);
            await _context.SaveChangesAsync();

            return Ok(tecnico);
        }
    }
}
