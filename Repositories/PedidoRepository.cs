using CarRent.Context;
using CarRent.Models;
using CarRent.Repositories.Interfaces;

namespace CarRent.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext appDbContext;
    private readonly CarrinhoCompra _carrinhoCompra;

    public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
    {
        this.appDbContext = appDbContext;
        _carrinhoCompra = carrinhoCompra;
    }

    public void CriarPedido(Pedido pedido)
    {
        pedido.PedidoEnviado = DateTime.Now;
        appDbContext.Pedidos.Add(pedido);
        appDbContext.SaveChanges();

        var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

        foreach(var carrinhoItem in carrinhoCompraItens)
        {
            var pedidoDetail = new PedidoDetalhe()
            {
                Quantidade = carrinhoItem.Quantidade,
                CarroId = carrinhoItem.Carro.CarroId,
                PedidoId = pedido.PedidoId,
                Preco = carrinhoItem.Carro.Preco
            };

            appDbContext.PedidoDetalhes.Add(pedidoDetail);  
        }

        appDbContext.SaveChanges();
    }
}
