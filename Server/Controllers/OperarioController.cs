using AdminHerramientas.Server.Models;
using AdminHerramientas.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminHerramientas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperarioController : ControllerBase
    {
        private readonly AlpContext _context;

        public OperarioController(AlpContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Operario>>> GetOperarios()
        {
            return await _context.Operarios.Where(o => o.Activo == true).AsNoTracking().ToListAsync();
        }
    }
}
