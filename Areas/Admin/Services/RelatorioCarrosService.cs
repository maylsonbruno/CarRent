using CarRent.Context;
using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Areas.Admin.Services
{
    public class RelatorioCarrosService
    {
        private readonly AppDbContext _context;

        public RelatorioCarrosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Carro>> GetCarrosReport()
        {
            var carros = await _context.Carros.ToListAsync();

            if(carros is null)
                return default(IEnumerable<Carro>);

            return carros;
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasReport()
        {
            var categorias = await _context.Categorias.ToListAsync();

            if (categorias is null)
                return default(IEnumerable<Categoria>);


            return categorias;
        }
    }
}
