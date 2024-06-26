﻿// <auto-generated />
using System;
using CarRent.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRent.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240402211936_Pedidos")]
    partial class Pedidos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarRent.Models.CarrinhoCompraItem", b =>
                {
                    b.Property<int>("CarrinhoCompraItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarrinhoCompraItemId"), 1L, 1);

                    b.Property<string>("CarrinhoCompraId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("CarroId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("CarrinhoCompraItemId");

                    b.HasIndex("CarroId");

                    b.ToTable("CarrinhoCompraItems");
                });

            modelBuilder.Entity("CarRent.Models.Carro", b =>
                {
                    b.Property<int>("CarroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarroId"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Estoque")
                        .HasColumnType("bit");

                    b.Property<string>("ImageCar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kilometragem")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("StatusCarro")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarroId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("CarRent.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<DateTime>("AnoFabricacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("CarRent.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoId"), 1L, 1);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Cidade")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Endereco1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Endereco2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estado")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("PedidoEntregueEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PedidoEnviado")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PedidoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("TotalItensPedido")
                        .HasColumnType("int");

                    b.HasKey("PedidoId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("CarRent.Models.PedidoDetalhe", b =>
                {
                    b.Property<int>("PedidoDetalheId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoDetalheId"), 1L, 1);

                    b.Property<int>("CarroId")
                        .HasColumnType("int");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("PedidoDetalheId");

                    b.HasIndex("CarroId");

                    b.HasIndex("PedidoId");

                    b.ToTable("PedidoDetalhes");
                });

            modelBuilder.Entity("CarRent.Models.CarrinhoCompraItem", b =>
                {
                    b.HasOne("CarRent.Models.Carro", "Carro")
                        .WithMany()
                        .HasForeignKey("CarroId");

                    b.Navigation("Carro");
                });

            modelBuilder.Entity("CarRent.Models.Carro", b =>
                {
                    b.HasOne("CarRent.Models.Categoria", "Categoria")
                        .WithMany("Carros")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("CarRent.Models.PedidoDetalhe", b =>
                {
                    b.HasOne("CarRent.Models.Carro", "Carro")
                        .WithMany()
                        .HasForeignKey("CarroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRent.Models.Pedido", "Pedido")
                        .WithMany("PedidoItens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carro");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("CarRent.Models.Categoria", b =>
                {
                    b.Navigation("Carros");
                });

            modelBuilder.Entity("CarRent.Models.Pedido", b =>
                {
                    b.Navigation("PedidoItens");
                });
#pragma warning restore 612, 618
        }
    }
}
