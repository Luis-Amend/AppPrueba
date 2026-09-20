using AppPrueba.Data;
using AppPrueba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppPrueba.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TipoAutoController : Controller
{
    private readonly ApplicationDbContext _context;

    public TipoAutoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> ListadoTipos()
    {
        var tipos = await _context.Tipos.ToListAsync();

        return Ok(tipos);
    }

    [HttpPost]
    public async Task<IActionResult> CrearTipo([FromBody] TipoAuto tipo)
    {
        var nombreMayuscula = tipo.Nombre?.Trim().ToUpper();

        var existeTipo = await _context.Tipos.AnyAsync(e => e.Nombre == nombreMayuscula);

        if (!existeTipo)
        {
            var nuevoTipo = new TipoAuto
            {
                Nombre = nombreMayuscula,
            };
                            _context.Add(nuevoTipo);
            await _context.SaveChangesAsync();
            return Ok("Tipo guardado");
        }

        return Ok();

    }

    [HttpPut("{tipoID}")]
    public async Task<IActionResult> EditarTipo(int tipoID, [FromBody]TipoAuto tipo)
    {
        var tipoMayuscula = tipo.Nombre?.Trim().ToUpper();
        var editarTipo = await _context.Tipos.Where(e => e.TipoId == tipoID).SingleOrDefaultAsync();

        if (editarTipo == null)
        {
        return Ok("el tipo que quiere editar no existe");
        };

        var existeNombre = await _context.Tipos.AnyAsync(e => e.Nombre == tipoMayuscula && e.TipoId != tipoID);

        if (!existeNombre)
        {
            editarTipo.Nombre = tipoMayuscula;
            await _context.SaveChangesAsync();

            return Ok("tipo editado exitosamente");
        }
        return Ok("ya existe un tipo con ese nombre");
    }

    [HttpDelete("{tipoID}")]
    public async Task<IActionResult> EliminarTipo(int tipoID)
    {
        var tipoAuto = await _context.Tipos.FindAsync(tipoID);

        if (tipoAuto == null)
        {
            return Ok("el tipo que quiere eliminar no existe");
        }

        _context.Tipos.Remove(tipoAuto);
        await _context.SaveChangesAsync();

        return Ok("tipo eliminado exitosamente");
    }

    [HttpGet("{tipoID}")]
    public async Task<IActionResult> ObtenerTipo(int tipoID)
    {
        var tipoAuto = await _context.Tipos.FindAsync(tipoID);

        if (tipoAuto == null)
        {
            return Ok("el tipo que quiere obtener no existe");
        }

        return Ok(tipoAuto);
    }
}