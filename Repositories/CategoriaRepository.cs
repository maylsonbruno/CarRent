using CarRent.Context;
using CarRent.Models;
using CarRent.Repositories.Interfaces;

namespace CarRent.Repositories;

public class CategoriaRepository : ICategoriaRepository
{ 

    private readonly AppDbContext  _context;

    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Categoria> Categorias => _context.Categorias;
}
