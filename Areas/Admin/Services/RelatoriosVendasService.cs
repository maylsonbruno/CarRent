using CarRent.Context;
using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Areas.Admin.Services
{
    public class RelatoriosVendasService
    {
        private readonly AppDbContext context;

        public RelatoriosVendasService(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in context.Pedidos select obj;

            if(minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado == minDate.Value);

            }

            if(maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
            }

            return await resultado
                .Include(l => l.PedidoItens)
                .ThenInclude(l => l.Carro)
                .OrderByDescending(x => x.PedidoEnviado)
                .ToListAsync();
         }


    }
}
