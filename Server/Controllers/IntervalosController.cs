using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminHerramientas.Server.Models;
using AdminHerramientas.Shared.Models;

namespace AdminHerramientas.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntervalosController : ControllerBase
    {
        private readonly AlpContext _context;

        public IntervalosController(AlpContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intervalo>>> GetIntervalos()
        {
            return await _context.Intervalos.AsNoTracking().ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CrearIntervalo(Intervalo intervalo)
        {
            _context.Intervalos.Add(intervalo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarIntervalo(int id, Intervalo intervalo)
        {
            if (id != intervalo.Id) return BadRequest();

            _context.Entry(intervalo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}