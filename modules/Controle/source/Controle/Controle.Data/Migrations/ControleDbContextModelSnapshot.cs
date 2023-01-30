﻿// <auto-generated />
using System;
using Controle.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Controle.Data.Migrations
{
    [DbContext(typeof(ControleDbContext))]
    partial class ControleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Controle.Data.Models.Carrinho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Carrinhos");
                });

            modelBuilder.Entity("Controle.Data.Models.Carteira", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float?>("Valor")
                        .IsRequired()
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Carteira", (string)null);
                });

            modelBuilder.Entity("Controle.Data.Models.Contas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoriaConta")
                        .HasColumnType("integer");

                    b.Property<bool?>("ContaFixa")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("DataInsercao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("IsPago")
                        .HasColumnType("boolean");

                    b.Property<string>("NomeConta")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("ValorTotal")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Contas", (string)null);
                });

            modelBuilder.Entity("Controle.Data.Models.ContasCategorias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DataInsersao")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ContasCategorias", (string)null);
                });

            modelBuilder.Entity("Controle.Data.Models.ContasParcelas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataVencimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("IdConta")
                        .HasColumnType("integer");

                    b.Property<bool?>("IsPago")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("Valor")
                        .IsRequired()
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("IdConta");

                    b.ToTable("ContasParcelas", (string)null);
                });

            modelBuilder.Entity("Controle.Data.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarrinhoId")
                        .HasColumnType("integer");

                    b.Property<int?>("CategoriaProdutoId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoId");

                    b.HasIndex("CategoriaProdutoId");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("Controle.Data.Models.ProdutoCategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DataInsercao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProdutoCategoria", (string)null);
                });

            modelBuilder.Entity("Controle.Data.Models.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Dia")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tarefa", (string)null);
                });

            modelBuilder.Entity("Controle.Data.Models.TarefasItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Dia")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TarefaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TarefaId");

                    b.ToTable("TarefaItem", (string)null);
                });

            modelBuilder.Entity("Controle.Data.Models.Transacoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Cancelado")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("Data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("IdConta")
                        .HasColumnType("integer");

                    b.Property<int?>("IdParcela")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TipoTransacao")
                        .HasColumnType("integer");

                    b.Property<float?>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Transacoes", (string)null);
                });

            modelBuilder.Entity("Controle.Data.Models.ContasParcelas", b =>
                {
                    b.HasOne("Controle.Data.Models.Contas", "Contas")
                        .WithMany("Parcelas")
                        .HasForeignKey("IdConta");

                    b.Navigation("Contas");
                });

            modelBuilder.Entity("Controle.Data.Models.Produto", b =>
                {
                    b.HasOne("Controle.Data.Models.Carrinho", null)
                        .WithMany("Produtos")
                        .HasForeignKey("CarrinhoId");

                    b.HasOne("Controle.Data.Models.ProdutoCategoria", "CategoriaProduto")
                        .WithMany()
                        .HasForeignKey("CategoriaProdutoId");

                    b.Navigation("CategoriaProduto");
                });

            modelBuilder.Entity("Controle.Data.Models.TarefasItem", b =>
                {
                    b.HasOne("Controle.Data.Models.Tarefa", "Tarefa")
                        .WithMany("Tarefas")
                        .HasForeignKey("TarefaId");

                    b.Navigation("Tarefa");
                });

            modelBuilder.Entity("Controle.Data.Models.Carrinho", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Controle.Data.Models.Contas", b =>
                {
                    b.Navigation("Parcelas");
                });

            modelBuilder.Entity("Controle.Data.Models.Tarefa", b =>
                {
                    b.Navigation("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}
