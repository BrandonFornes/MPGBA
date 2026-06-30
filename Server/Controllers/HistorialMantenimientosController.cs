using AdminHerramientas.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using AdminHerramientas.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminHerramientas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialMantenimientosController : ControllerBase
    {
        private readonly AlpContext _context;
        public HistorialMantenimientosController(AlpContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<HistorialMantenimiento>>> GetHistorial()
        {
            var mantenimientos = await _context.HistorialMantenimientos.ToListAsync();
            return Ok(mantenimientos);
        }

        [HttpPost]
        public async Task<IActionResult> CrearMantenimiento(HistorialMantenimiento mantenimiento)
        {
            _context.HistorialMantenimientos.Add(mantenimiento);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarMantenimiento(int id, HistorialMantenimiento mantenimiento)
        {
            if (id != mantenimiento.Id) return BadRequest();

            _context.Entry(mantenimiento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}