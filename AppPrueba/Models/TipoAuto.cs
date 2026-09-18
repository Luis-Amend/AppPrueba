using System.ComponentModel.DataAnnotations;

namespace AppPrueba.Models;

public class TipoAuto
{
    [Key]
    public int TipoId { get; set; }
    public string? Nombre { get; set; }


    public ICollection<Auto>? Autos { get; set; }
    public ICollection<MarcaAuto>? Marcas { get; set; }
}