using CarRent.Models;

namespace CarRent.ViewModels;

public class CarroListViewModel
{
    public IEnumerable<Carro> Carro { get; set; }
    public string CategoriaAtual { get; set; }

}
