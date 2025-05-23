﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedesSociaisApp.Infrastructure.Persistence;

#nullable disable

namespace RedesSociaisApp.Infrastructure.Migrations
{
    [DbContext(typeof(RedesSociaisDbContext))]
    [Migration("20241106204451_IncluiId")]
    partial class IncluiId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("RedesSociaisApp.Domain.Entities.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("RedesSociaisApp.Domain.Entities.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdConta")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeExibicao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sobre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdConta")
                        .IsUnique();

                    b.ToTable("Perfis");
                });

            modelBuilder.Entity("RedesSociaisApp.Domain.Entities.Publicacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Localidade")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdPerfil");

                    b.ToTable("Publicacoes");
                });

            modelBuilder.Entity("RedesSociaisApp.Domain.Entities.Perfil", b =>
                {
                    b.HasOne("RedesSociaisApp.Domain.Entities.Conta", "Conta")
                        .WithOne("Perfil")
                        .HasForeignKey("RedesSociaisApp.Domain.Entities.Perfil", "IdConta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("RedesSociaisApp.Domain.Entities.Publicacao", b =>
                {
                    b.HasOne("RedesSociaisApp.Domain.Entities.Perfil", "Perfil")
                        .WithMany("Publicacoes")
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("RedesSociaisApp.Domain.Entities.Conta", b =>
                {
                    b.Navigation("Perfil")
                        .IsRequired();
                });

            modelBuilder.Entity("RedesSociaisApp.Domain.Entities.Perfil", b =>
                {
                    b.Navigation("Publicacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
