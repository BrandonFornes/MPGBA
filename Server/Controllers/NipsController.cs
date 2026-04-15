using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminHerramientas.Server.Models;
using AdminHerramientas.Shared.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AdminHerramientas.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NipsController : ControllerBase
    {
        private readonly AlpContext _context;

        public NipsController(AlpContext context)
        {
            _context = context;
        }

        [HttpGet("validar")]
        public async Task<ActionResult<bool>> ValidarNip(string operario, string pin)
        {
            var esValido = await _context.Nips
                .AnyAsync(n => n.Fk_codigoOperario == operario 
                            && n.ValorNip == pin 
                            && n.Activo);
            
            return Ok(esValido);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nip>>> GetNips()
        {
            return await _context.Nips.AsNoTracking().ToListAsync();
        }
    }
}