using AdminHerramientas.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using AdminHerramientas.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminHerramientas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrosLavadosController : ControllerBase
    {
        private readonly AlpContext _context;

        public RegistrosLavadosController(AlpContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<RegistrosLavado>>> GetRegistros()
        {
            var registros = await _context.RegistrosLavados.Where(r => r.Activo == true).ToListAsync();
            return Ok(registros);
        }

        [HttpPost]
        public async Task<IActionResult> CrearRegistro(RegistrosLavado registro)
        {
            _context.RegistrosLavados.Add(registro);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarRegistro(int id, RegistrosLavado registro)
        {
            if (id != registro.Id) return BadRequest();

            _context.Entry(registro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}