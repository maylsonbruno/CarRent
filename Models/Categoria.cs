using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Modelo { get; set; }

        public DateTime AnoFabricacao { get; set; }

        public ICollection<Carro>  Carros{ get; set; } = new List<Carro>();
    }
}
