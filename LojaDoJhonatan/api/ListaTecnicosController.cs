using LojaDoJhonatan.dominio;
using LojaDoJhonatan.infraestrutura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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

        

    }


}
