using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models;

public class PedidoDetalhe
{
    public int PedidoDetalheId { get; set; }
    public int PedidoId { get; set; }
    public int CarroId { get; set; }
    public int Quantidade { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Preco { get; set; }
    public virtual Carro Carro { get; set; }
    public virtual Pedido Pedido { get; set; }
}
