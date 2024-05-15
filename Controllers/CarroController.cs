using CarRent.Models;
using CarRent.Repositories.Interfaces;
using CarRent.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    public class CarroController : Controller
    {
        private readonly ICarRentReposityory _carRentReposityory;

        public CarroController(ICarRentReposityory carRentReposityory)
        {
            _carRentReposityory = carRentReposityory;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Carro> carros;
            string categoriaAtual = string.Empty;

            if(string.IsNullOrEmpty(categoria))
            {
                carros = _carRentReposityory.Carros.OrderBy(l=>l.CarroId);
                categoriaAtual = "Todos os carros";
            }
            else
            {
                // if(string.Equals("Esportivo", categoria, StringComparison.OrdinalIgnoreCase))
                // {
                //   carro =_carRentReposityory.Carros.
                //         Where(x => x.Categoria.Modelo.Equals("Esportivo"))
                //         .OrderBy(l=>l.StatusCarro);
                // }

                //if(string.Equals("Elegance", categoria, StringComparison.OrdinalIgnoreCase))
                // {
                //     carro = _carRentReposityory.Carros.
                //        Where(x => x.Categoria.Modelo.Equals("Elegance"))
                //        .OrderBy(l => l.StatusCarro);
                // }

                carros = _carRentReposityory.Carros
                     .Where(l => l.Categoria.Modelo.Equals(categoria))
                     .OrderBy(l => l.Marca);
                
                categoriaAtual = categoria;
            }

            var carroListViewModel = new CarroListViewModel
            {
                Carro = carros,
                CategoriaAtual=categoriaAtual,
            };



            return View(carroListViewModel);
        }

        public IActionResult Details(int carroId)
        {
            var carros = _carRentReposityory.Carros.FirstOrDefault(c => c.CarroId == carroId);
            return View(carros);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Carro> carros;
            string categoriaAtual = string.Empty;

            if(string.IsNullOrEmpty(searchString))
            {
                carros = _carRentReposityory.Carros.OrderBy(p => p.CarroId);
                categoriaAtual = "Todos os Carros";
            }
            else
            {
                carros = _carRentReposityory.Carros
                    .Where(p => p.Marca.ToLower().Contains(searchString.ToLower()));

                if (carros.Any())

                    categoriaAtual = "Carros";
                else
                    categoriaAtual = "Nenhum carro foi encontrado";
            }

            return View("~/Views/Carro/List.cshtml", new CarroListViewModel
            {
                Carro = carros,
                CategoriaAtual = categoriaAtual
            });

        }
    }
}
