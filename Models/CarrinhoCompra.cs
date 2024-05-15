using CarRent.Context;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Models;

public class CarrinhoCompra
{
    public string CarrinhoCompraId { get; set; }
    public  List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
    private readonly AppDbContext _context;

    public CarrinhoCompra(AppDbContext context)
    {
        _context = context;
    }

    public static CarrinhoCompra CarrinhoCompraGetCarrinho(IServiceProvider services)
    {
        //define uma Sessão
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        //obtem um serviço do tipo do nosso contexto
        var context = services.GetService<AppDbContext>();

        //obtem ou gera o Id do carrinho
        string carrinhoId = session.GetString("CarrinhoId")??Guid.NewGuid().ToString();

        //atribui o id do carrinho na Sessão
        session.SetString("CarrinhoId",carrinhoId);

        //retorna o carrinho com o contexto e o Id atribuido ou obtido
        return new CarrinhoCompra(context)
        {
            CarrinhoCompraId = carrinhoId
        };
    }

    public void AdicionarAoCarrinho(Carro carro)
    {
        var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(
            s => s.Carro.CarroId == carro.CarroId &&
            s.CarrinhoCompraId == CarrinhoCompraId);

        if(carrinhoCompraItem == null)
        {
            carrinhoCompraItem = new CarrinhoCompraItem 
            { 
             CarrinhoCompraId = CarrinhoCompraId,
             Carro = carro,
             Quantidade = 1
            };

            _context.CarrinhoCompraItems.Add(carrinhoCompraItem);   

        }
        else
        {
            carrinhoCompraItem.Quantidade++;
        }

        _context.SaveChanges();

    }

    public int RemoverDoCarrinho(Carro carro)
    {
        var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(
          s => s.Carro.CarroId == carro.CarroId &&
          s.CarrinhoCompraId == CarrinhoCompraId);

        var quantidadeLocal = 0;

        if(carrinhoCompraItem != null)
        {
            if(carrinhoCompraItem.Quantidade > 1)
            {
                carrinhoCompraItem.Quantidade--;
                quantidadeLocal = carrinhoCompraItem.Quantidade;
            }
            else
            {
                _context.CarrinhoCompraItems.Remove(carrinhoCompraItem);

            }
        }

        _context.SaveChanges();
        return quantidadeLocal;
    }

    public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
    {
        return CarrinhoCompraItens ?? 
             (CarrinhoCompraItens =
              _context.CarrinhoCompraItems
              .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
              .Include(s => s.Carro)
              .ToList());

    }

    public void LimparCarrinho()
    {
        var carrinhoItens = _context.CarrinhoCompraItems
            .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

        _context.CarrinhoCompraItems.RemoveRange(carrinhoItens);
        _context.SaveChanges();
    }

    public decimal GetCarrinhoCompraTotal()
    {
        var total = _context.CarrinhoCompraItems
              .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
              .Select(c => c.Carro.Preco * c.Quantidade).Sum();
        return total;
    }

}
