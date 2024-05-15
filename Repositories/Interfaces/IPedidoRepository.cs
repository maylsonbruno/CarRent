using CarRent.Models;

namespace CarRent.Repositories.Interfaces;

public interface IPedidoRepository
{
    void CriarPedido(Pedido pedido);
}
