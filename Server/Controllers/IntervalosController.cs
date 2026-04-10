using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminHerramientas.Server.Models;
using AdminHerramientas.Shared.Models;

namespace AdminHerramientas.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IntervalosController : ControllerBase
{
    private readonly AlpContext _context;

    public IntervalosController(AlpContext context)
    {
        _context = context;
    }

    // GET: api/Intervalos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Intervalo>>> GetIntervalos()
    {
        // Usamos AsNoTracking para que sea súper rápido, ya que es consulta
        return await _context.Intervalos.AsNoTracking().ToListAsync();
    }

}