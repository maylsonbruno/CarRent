using CarRent.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
     
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }
        public  DbSet<Categoria> Categorias { get; set; }
        public  DbSet<Carro> Carros { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }


    }
}
