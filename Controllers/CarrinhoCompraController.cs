using CarRent.Models;
using CarRent.Repositories.Interfaces;
using CarRent.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers;
public class CarrinhoCompraController : Controller
{
    private readonly ICarRentReposityory _carRentRepository;
    private readonly CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraController(ICarRentReposityory carRentRepository, CarrinhoCompra carrinhoCompra)
    {
        _carRentRepository = carRentRepository;
        _carrinhoCompra = carrinhoCompra;
    }
    
    public IActionResult Index()
    {
        var itens = _carrinhoCompra.GetCarrinhoCompraItems();
         _carrinhoCompra.CarrinhoCompraItens = itens;

        var carrinhoCompraVM = new CarrinhoCompraViewModel 
        { 
            CarrinhoCompra = _carrinhoCompra,
            CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()

        };

        return View(carrinhoCompraVM);
    }

    [Authorize]
    public IActionResult AdicionarItemNoCarrinhoCompra(int carroId)
    {
        var carroSelecionado = _carRentRepository.Carros.
            FirstOrDefault(p => p.CarroId == carroId);

        if(carroSelecionado != null)
        {
            _carrinhoCompra.AdicionarAoCarrinho(carroSelecionado);
        }
        return RedirectToAction("Index");
    }
    [Authorize]
    public IActionResult RemoverItemDoCarrinhoCompra(int carroId)
    {
        var carroSelecionado = _carRentRepository.Carros.
           FirstOrDefault(p => p.CarroId == carroId);

        if (carroSelecionado != null)
        {
            _carrinhoCompra.RemoverDoCarrinho(carroSelecionado);
        }
        return RedirectToAction("Index");
    }
}
