using CarRent.Models;

namespace CarRent.ViewModels
{
    public class PedidoCarroViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
