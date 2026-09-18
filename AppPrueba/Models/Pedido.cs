using System.ComponentModel.DataAnnotations;

namespace AppPrueba.Models;

public class Pedido
{
    [Key]
    public int PedidoId { get; set;}
    public string? NombreCliente { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? Fecha { get; set; }
    public string? Estado { get; set; }
    public string? PrecioTotal { get; set; }


    public ICollection<DetallePedido>? DetallePedidos { get; set; }


}