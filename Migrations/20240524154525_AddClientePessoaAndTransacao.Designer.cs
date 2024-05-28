﻿// <auto-generated />
using System;
using BancoSimples.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BancoSimples.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240524154525_AddClientePessoaAndTransacao")]
    partial class AddClientePessoaAndTransacao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BancoSimples.Domain.Conta.ClientePessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ClientePessoa");
                });

            modelBuilder.Entity("BancoSimples.Domain.Conta.Transacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.Property<string>("TipoMovimentacao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Transacao");
                });
#pragma warning restore 612, 618
        }
    }
}
