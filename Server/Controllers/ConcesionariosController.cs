using AdminHerramientas.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using AdminHerramientas.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminHerramientas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConcesionariosController : ControllerBase
    {
        private readonly AlpContext _context;
        public ConcesionariosController(AlpContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Concesionario>>> GetConcesionarios()
        {
            var concesionarios = await _context.Concesionarios.AsNoTracking().ToListAsync();
            return Ok(concesionarios);
        }
    }
}