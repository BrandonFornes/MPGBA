using AdminHerramientas.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdminHerramientas.Server.Models;
using Microsoft.EntityFrameworkCore;

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


        // GET: HerramientaController

        [HttpGet]
        public async Task<ActionResult<List<HerramientasDetalle>>> GetHerramientas()
        {
            var herramientas = await _context.HerramientasDetalles.ToListAsync();
            return Ok(herramientas);
        }
        [HttpPost]
        public async Task<IActionResult> CrearHerramienta(HerramientasDetalle herramientaDetalle)
        {
            _context.HerramientasDetalles.Add(herramientaDetalle);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> EditarHerramienta(HerramientasDetalle herramientaDetalle)
        {
            _context.HerramientasDetalles.Update(herramientaDetalle);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }

}
