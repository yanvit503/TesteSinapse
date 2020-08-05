﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteSinapse.Data;

namespace TesteSinapse.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20200805194828_ClienteVisivel")]
    partial class ClienteVisivel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TesteSinapse.Models.Cliente", b =>
                {
                    b.Property<int>("Cod_Cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data_Cadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo_Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<bool>("Visivel")
                        .HasColumnType("bit");

                    b.HasKey("Cod_Cliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("TesteSinapse.Models.Fatura", b =>
                {
                    b.Property<int>("Num_Fatura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cod_Cliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data_Emissao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Vencimento")
                        .HasColumnType("datetime2");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Num_Fatura");

                    b.ToTable("Faturas");
                });
#pragma warning restore 612, 618
        }
    }
}
