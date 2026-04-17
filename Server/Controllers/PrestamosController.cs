using AdminHerramientas.Server.Models;
using AdminHerramientas.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminHerramientas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamosController : ControllerBase
    {
        private readonly AlpContext _context;
        public PrestamosController(AlpContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Prestamo>>> GetPrestamos()
        {
            var prestamos = await _context.Prestamos
                .AsNoTracking()
                .Include(p => p.PrestamosDetalles)
                .ToListAsync();
            return Ok(prestamos);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPrestamo(Prestamo prestamo)
        {
            if (prestamo == null || prestamo.PrestamosDetalles == null || !prestamo.PrestamosDetalles.Any())
            {
                return BadRequest("No se puede crear un préstamo sin herramientas.");
            }

            try
            {
                var idsHerramientas = prestamo.PrestamosDetalles.Select(d => d.FkIdHerramienta).ToList();
                var herramientasFisicas = await _context.HerramientasDetalles
                    .Where(h => idsHerramientas.Contains(h.Id))
                    .ToListAsync();

                foreach (var herramienta in herramientasFisicas)
                {
                    if (herramienta.Disponible == false)
                    {
                        return BadRequest($"La herramienta {herramienta.Descripcion} ({herramienta.Etiqueta}) ya no está disponible.");
                    }

                    herramienta.Disponible = false;
                    herramienta.FechaModificacion = DateTime.Now;
                }
                _context.Prestamos.Add(prestamo);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error crítico al crear el préstamo: {ex.Message}");
            }
        }

        [HttpPut("devolver")]
        public async Task<IActionResult> RegistrarDevolucion([FromBody] List<PrestamosDetalle> detallesDevueltos)
        {
            try
            {
                var idsHerramientas = detallesDevueltos.Select(d => d.FkIdHerramienta).ToList();
                var herramientasFisicas = await _context.HerramientasDetalles
                    .Where(h => idsHerramientas.Contains(h.Id))
                    .ToListAsync();


                foreach (var detalle in detallesDevueltos)
                {
                    _context.Entry(detalle).State = EntityState.Modified;

                    var herramientaFisica = herramientasFisicas.FirstOrDefault(h => h.Id == detalle.FkIdHerramienta);

                    if (herramientaFisica != null)
                    {
                        
                        herramientaFisica.Disponible = true;
                        herramientaFisica.FechaModificacion = DateTime.Now;
                    }
                }
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la devolución: {ex.Message}");
            }
        }

    }
}
