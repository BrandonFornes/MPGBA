using AdminHerramientas.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using AdminHerramientas.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminHerramientas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculosController : ControllerBase
    {
        private readonly AlpContext _context;
        public VehiculosController(AlpContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vehiculo>>> GetVehiculos()
        {
            var vehiculos = await _context.Vehiculos.ToListAsync();
            return Ok(vehiculos);
        }

        [HttpPost]
        public async Task<IActionResult> CrearVehiculo(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{bastidor}")]
        public async Task<IActionResult> EditarVehiculo(string bastidor, Vehiculo vehiculo)
        {
            if (!bastidor.Equals(vehiculo.Bastidor)) return BadRequest();

            _context.Entry(vehiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}