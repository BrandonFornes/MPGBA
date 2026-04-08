using AdminHerramientas.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using AdminHerramientas.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminHerramientas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresasController : ControllerBase
    {
        private readonly AlpContext _context;
        public EmpresasController(AlpContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Empresa>>> GetEmpresas()
        {
            var empresas = await _context.Empresas.ToListAsync();
            return Ok(empresas);
        }
    }
}