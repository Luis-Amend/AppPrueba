using Microsoft.EntityFrameworkCore;
using AppPrueba.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Auto> Autos { get; set; }
    public DbSet<MarcaAuto> Marcas { get; set; }
    public DbSet<TipoAuto> Tipos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<DetallePedido> DetallePedidos { get; set; }

}