using AdminHerramientas.Server.Models;
using AdminHerramientas.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static MudBlazor.CategoryTypes;

namespace AdminHerramientas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HerramientasDetallesController : ControllerBase
    {
        private readonly AlpContext _context;
        public HerramientasDetallesController(AlpContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<HerramientasDetalle>>> GetHerramientas()
        {
            var herramientas = await _context.HerramientasDetalles
                .AsNoTracking()
                .Where(h => h.Activo == true).ToListAsync();
            return Ok(herramientas);
        }
        [HttpPost]
        public async Task<IActionResult> CrearHerramienta(HerramientasDetalle herramientaDetalle)
        {
            _context.HerramientasDetalles.Add(herramientaDetalle);
            await _context.SaveChangesAsync();
            return Ok(herramientaDetalle);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarHerramienta(int id, HerramientasDetalle item)
        {
            if (id != item.Id) return BadRequest("El ID de la herramienta no coincide.");

            int filasAfectadas = await _context.HerramientasDetalles
                .Where(h => h.Id == item.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(h => h.Descripcion, item.Descripcion)
                    .SetProperty(h => h.Etiqueta, item.Etiqueta)
                    .SetProperty(h => h.FechaCompra, item.FechaCompra)
                    .SetProperty(h => h.Disponible, item.Disponible)
                    .SetProperty(h => h.Estado, item.Estado)
                    .SetProperty(h => h.FechaModificacion, DateTime.Now)
                );
            if (filasAfectadas == 0) return NotFound();

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHerramientasDetalle(int id)
        {
            var herramienta = await _context.HerramientasDetalles.FindAsync(id);

            if (herramienta == null)
            {
                return NotFound("La herramienta no fue encontrada.");
            }
            herramienta.Activo = false;
            _context.Entry(herramienta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("La herramienta ha sido eliminada.");
        }
    }

}
