using CarRent.Context;
using CarRent.Models;
using CarRent.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace CarRent.Repositories;

public class CarroRepository : ICarRentReposityory
{
    private readonly AppDbContext _context;

    public CarroRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Carro> Carros => _context.Carros.Include(y=> y.Categoria);

    public IEnumerable<Carro> CarrosEstoque => _context.Carros.Where(x => x.Estoque).Include(y=> y.Categoria);

    public Carro GetCarroById(int id) => _context.Carros.FirstOrDefault(x=> x.CarroId == id);
   
}
