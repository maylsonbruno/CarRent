using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRent.Migrations
{
    public partial class PopularCategoria : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Categorias(Modelo,AnoFabricacao) VALUES('Esportivo','2000-05-06')");
            mb.Sql("INSERT INTO Categorias(Modelo,AnoFabricacao) VALUES('Off-Road','2024-07-08')");
            mb.Sql("INSERT INTO Categorias(Modelo,AnoFabricacao) VALUES('Elegance','2002-03-01')");
            mb.Sql("INSERT INTO Categorias(Modelo,AnoFabricacao) VALUES('Passeio','2018-09-12')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Categorias");
        }
    }
}
