using AdminHerramientas.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using AdminHerramientas.Server.Models;
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
        public IActionResult GetHerramientas()
        {
            var herramientas = _context.Herramientas.ToList();
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
