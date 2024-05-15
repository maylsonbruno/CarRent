namespace CarRent.Models
{
    public class ImageCars
    {
        public int ImageCarsId { get; set; }

        public int CarroId { get; set; }
        public Carro Carro { get; set; }
    }
}
