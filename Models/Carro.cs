using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace CarRent.Models
{
    public class Carro
    {
        public int CarroId { get; set; }
        [StringLength(100,ErrorMessage = "O nome do modelo não deve passar de 100")] 
        [Required(ErrorMessage = "O Modelo do Carro dever ser Informado")]
        [Display(Name = "Modelo do Carro")]
        public string Marca{ get; set; }
        public int Kilometragem { get; set; }
        public string Cor { get; set; }
        public string StatusCarro { get; set; }
        [Required]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [StringLength(200, ErrorMessage = "A Descrição deve possuir 200 caracteres")]
        public string Descricao { get; set; }
        public string ImageCar { get; set; }
        public bool Estoque { get; set; }

        //Chave Estrangeira da classe categoria
        [JsonIgnore]
        public int CategoriaId { get; set; }
        // Propriedade para navegação
        public Categoria Categoria { get; set; }

    }
}
