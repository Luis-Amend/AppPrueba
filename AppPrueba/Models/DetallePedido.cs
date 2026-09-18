using System.ComponentModel.DataAnnotations;

namespace AppPrueba.Models;

public class DetallePedido
{
    [Key]
    public int DetallePedidoId { get; set; }
    public string? Cantidad { get; set; }
    public string? Subtotal { get; set; }


    public virtual Pedido? Pedido { get; set; }
    public int PedidoId { get; set; }
    public virtual Auto? Auto { get; set; }
    public int AutoId { get; set; }
}