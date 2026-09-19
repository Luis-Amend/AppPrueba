using AppPrueba.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppPrueba.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MarcaController : Controller
{
    private readonly ApplicationDbContext _context;

    public MarcaController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> ListadoMarcas()
    {
        var marcas = await _context.Marcas.ToListAsync();

        return Ok(marcas);
    }

}

