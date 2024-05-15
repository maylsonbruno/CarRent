using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRent.Migrations
{
    public partial class PopularCarros : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Carros(CategoriaId,Marca,Kilometragem,Cor,StatusCarro,Preco,Descricao,ImageCar,Estoque)" +
              "VALUES(1,'BMW-320I',60.000,'AZUL','SEMI-NOVO',90000.00,'BMW em excelente codições','bmw-320i_formatada.jpg',1)");
            mb.Sql("INSERT INTO Carros(CategoriaId,Marca,Kilometragem,Cor,StatusCarro,Preco,Descricao,ImageCar,Estoque)" +
               "VALUES(2,'AUDIO-TT',50.000,'PRETO','SEMI-NOVO',100000.00,'AUDIO TT NOVO','audio_formatado.jpg',1)");
            mb.Sql("INSERT INTO Carros(CategoriaId,Marca,Kilometragem,Cor,StatusCarro,Preco,Descricao,ImageCar,Estoque)" +
               "VALUES(3,'FIAT-FASTBACK',0,'PRATA','NOVO',80000.00,'Fiat-FastBack lançamento','fiat_formatado.jpg',1)");
            mb.Sql("INSERT INTO Carros(CategoriaId,Marca,Kilometragem,Cor,StatusCarro,Preco,Descricao,ImageCar,Estoque)" +
               "VALUES(1,'CAMARO',30.000,'AMARELO','SEMI-NOVO',300000.00,'CAMARO SEMI-NOVO','camaro_formatado.jpg',1)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Carros");
        }
    }
}
