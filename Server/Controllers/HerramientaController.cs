using AdminHerramientas.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using AdminHerramientas.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminHerramientas.Server.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class HerramientaController : ControllerBase
    {
        private readonly AlpContext _context;
        public HerramientaController(AlpContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Herramienta>>> GetHerramientas()
        {
            var herramientas = await _context.Herramientas.Where(h => h.Activo == true).ToListAsync();
            return Ok(herramientas);
        }

        [HttpPost]
        public async Task<IActionResult> CrearTipoHerramienta(Herramienta herramienta)
        {
            _context.Herramientas.Add(herramienta);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarTipoHerramienta(int id,Herramienta herramienta)
        {
            if (id != herramienta.Id) return BadRequest("El ID de la herramienta no coincide.");

            int filasAfectadas = await _context.Herramientas
                .Where(h => h.Id == herramienta.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(h => h.Tipo, herramienta.Tipo)
                );
            if (filasAfectadas == 0) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoHerramienta(int id)
        {
            var herramienta = await _context.Herramientas.FindAsync(id);
            if (herramienta == null)
            {
                return NotFound("La herramienta no fue encontrada.");
            }
            herramienta.Activo = false;

            _context.Entry(herramienta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
