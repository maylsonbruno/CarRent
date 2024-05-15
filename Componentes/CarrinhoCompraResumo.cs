using CarRent.Models;
using CarRent.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Componentes;

public class CarrinhoCompraResumo : ViewComponent
{
    private readonly CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
    {
        _carrinhoCompra = carrinhoCompra;
    }

    public IViewComponentResult Invoke()
    {
        var itens = _carrinhoCompra.GetCarrinhoCompraItems();

        // Simulando itens no carrinho 
        //var itens = new List<CarrinhoCompraItem>() 
        //{ 
        //    new CarrinhoCompraItem(),
        //    new CarrinhoCompraItem()
        //};

        _carrinhoCompra.CarrinhoCompraItens = itens;

        var carrinhoCompraVM = new CarrinhoCompraViewModel
        { 
           CarrinhoCompra = _carrinhoCompra,
           CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()        
        };
        return View(carrinhoCompraVM);

    }
}
