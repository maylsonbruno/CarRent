using CarRent.Models;

namespace CarRent.Repositories.Interfaces
{
    public interface ICarRentReposityory
    {
        IEnumerable<Carro> Carros { get; }
        IEnumerable<Carro> CarrosEstoque { get; }

        Carro GetCarroById(int id);
       
    }
}
