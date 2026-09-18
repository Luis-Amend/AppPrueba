using System.ComponentModel.DataAnnotations;

namespace AppPrueba.Models;

public class Auto
{
    [Key]
    public int AutoId { get; set; }
    public string? Nombre { get; set; }
    public string? Modelo { get; set; }
    public string? Color { get; set; }
    public string? Traccion { get; set; }
    public string? Transmision { get; set; }
    public string? kilometraje { get; set; }
    public string? Precio { get; set; }
    public bool? Estado { get; set; }

    public virtual MarcaAuto? Marca { get; set; }
    public int MarcaId { get; set; }
    public virtual TipoAuto? Tipo { get; set; }
    public int TipoId { get; set; }


    public ICollection<DetallePedido>? DetallePedidos { get; set; }
}