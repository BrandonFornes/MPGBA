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
            var herramientas = await _context.Herramientas.ToListAsync();
            return Ok(herramientas);
        }

        [HttpPost]
        public async Task<IActionResult> CrearTipoHerramienta(Herramienta herramienta)
        {
            _context.Herramientas.Add(herramienta);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
