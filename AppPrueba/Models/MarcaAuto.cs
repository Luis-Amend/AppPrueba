using System.ComponentModel.DataAnnotations;

namespace AppPrueba.Models;

public class MarcaAuto
{
    [Key]
    public int MarcaId { get; set; }
    public string? Nombre { get; set; }
    public string? Origen { get; set;}

    public ICollection<Auto>? Autos { get; set; }
    public ICollection<TipoAuto>? Tipos { get; set; }
}