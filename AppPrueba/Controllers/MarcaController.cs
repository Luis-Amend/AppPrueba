using AppPrueba.Data;
using AppPrueba.Models;
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

    [HttpPost]
    public async Task<IActionResult> CrearMarca([FromBody] MarcaAuto marca)
    {
        var nombreMayuscula = marca.Nombre?.Trim().ToUpper();
        var origenMayuscula = marca.Origen?.Trim().ToUpper();

        var existeMarca = await _context.Marcas.AnyAsync(e => e.Nombre == nombreMayuscula);

        if (!existeMarca)
        {
            var nuevaMarca = new MarcaAuto 
            {
                Nombre = nombreMayuscula,
                Origen = origenMayuscula,
            };
                            _context.Add(nuevaMarca);
            await _context.SaveChangesAsync();
            return Ok("Marca guardada");
        }


        return Ok();
    }

    [HttpPut("{marcaID}")]
    public async Task<IActionResult> EditarMarca(int marcaID, [FromBody] MarcaAuto marca)
    {
        var marcaMayuscula = marca.Nombre?.Trim().ToUpper();
        var origenMayuscula = marca.Origen?.Trim().ToUpper();
        var editarMarca = await _context.Marcas.Where(e => e.MarcaId == marcaID).SingleOrDefaultAsync();

        if (editarMarca == null)
        {
        return Ok("la marca que quiere editar no existe");
        };

        var existeNombre = await _context.Marcas.AnyAsync(e => e.Nombre == marcaMayuscula && e.MarcaId != marcaID);

                //si el nombre es igual a la variable nombreMayuscula y que sea distinto al id guardado 

        if (!existeNombre)
        {
            editarMarca.Nombre = marcaMayuscula;
            editarMarca.Origen = origenMayuscula;
            await _context.SaveChangesAsync();

            return Ok("marca editada exitosamente");
        }
        return Ok("ya existe una marca con ese nombre");
    }

    [HttpDelete("{marcaID}")]
    public async Task<IActionResult> EliminarMarca(int marcaID)
    {
        var eliminarMarca = await _context.Marcas.Where(e => e.MarcaId == marcaID).SingleOrDefaultAsync();

        if (eliminarMarca == null)
        {
            return NotFound("marca no encontrada");
        }
        _context.Marcas.Remove(eliminarMarca);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("{marcaID}")]
    public async Task<IActionResult> ObtenerMarca(int marcaID)
    {
        var marca = await _context.Marcas.Where(e => e.MarcaId == marcaID).SingleOrDefaultAsync();

        if (marca == null)
        {
            return NotFound("marca no encontrada");
        }

        return Ok(marca);
    }

}

