using LojaDoJhonatan.dominio;
using LojaDoJhonatan.infraestrutura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace LojaDoJhonatan.api
{
    [ApiController]
    [Route("v1")]
    public class ListaCelularesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ListaCelularesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listacelulares")]
        public async Task<ActionResult<IEnumerable<Celular>>> Get()
        {
            var celulares = await _context.Celulares.ToListAsync();
            return Ok(celulares);
        }

        [HttpGet("listacelulares/{idCliente}")]
        public async Task<ActionResult<IEnumerable<Celular>>> GetPorIdeCliente(int idCliente)
        {
            var celulares = await _context.Celulares
                .Where(c => c.IdCliente == idCliente)
                .ToListAsync();

            if (celulares.Count() == 0)
            {
                return BadRequest(new { mensagem = "Não foi possível encontrar um celular com esse cliente." });

            }

            return Ok(celulares);
        }


        [HttpGet("listacelulares/marca/{marca}")]
        public async Task<ActionResult<IEnumerable<Celular>>> GetPorMarca(string marca)
        {


            var celulares = await _context.Celulares
                .Where(c => c.Marca == marca)
                .ToListAsync();

            if (celulares.Count() == 0)
            {
                return BadRequest(new { mensagem = "Não foi possível encontrar um celular com esse marca." });

            }

            return Ok(celulares);
        }

        [HttpGet("listacelulares/imei/{imei}")]
        public async Task<ActionResult<IEnumerable<Celular>>> GetPorimei(string imei)
        {


            var celulares = await _context.Celulares
                .Where(c => c.Imei == imei)
                .ToListAsync();

            if (celulares.Count() == 0)
            {
                return BadRequest(new { mensagem = "Não foi possível encontrar um celular com esse imei." + imei });

            }

            return Ok(celulares);
        }

        [HttpGet("listacelulares/modelo/{modelo}")]
        public async Task<ActionResult<IEnumerable<Celular>>> GetPormodelo(string modelo)
        {


            var celulares = await _context.Celulares
                .Where(c => c.Modelo == modelo)
                .ToListAsync();

            if (celulares.Count() == 0)
            {
                return BadRequest(new { mensagem = "Não foi possível encontrar um celular com esse modelo." + modelo });

            }

            return Ok(celulares);
        }
    }
}
