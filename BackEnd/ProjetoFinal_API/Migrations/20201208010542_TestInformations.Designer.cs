﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoFinal_API.Data;

namespace ProjetoFinal_API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201208010542_TestInformations")]
    partial class TestInformations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CompanyPerson", b =>
                {
                    b.Property<int>("CompaniesId")
                        .HasColumnType("int");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.HasKey("CompaniesId", "PeopleId");

                    b.HasIndex("PeopleId");

                    b.ToTable("CompanyPerson");
                });

            modelBuilder.Entity("ProjetoFinal_API.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Test"
                        });
                });

            modelBuilder.Entity("ProjetoFinal_API.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("Equipment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "HP",
                            Model = "Ink Sak",
                            SerialNumber = "BIASYRTCBO2U3809R2U38R",
                            Type = "Impressora"
                        });
                });

            modelBuilder.Entity("ProjetoFinal_API.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Cnpj")
                        .HasColumnType("VARCHAR(12)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasColumnType("VARCHAR(11)");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("PersonType")
                        .IsRequired()
                        .HasColumnType("CHAR(1)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("VARCHAR(16)");

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("CHAR(1)");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "casa do caraio",
                            Cnpj = "",
                            CompanyId = 1,
                            Cpf = "12345678901",
                            Email = "email@gmail.com",
                            Name = "Thomas",
                            PersonType = "P",
                            PhoneNumber = "1242535",
                            Type = "E"
                        });
                });

            modelBuilder.Entity("ProjetoFinal_API.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Demand")
                        .IsRequired()
                        .HasColumnType("VARCHAR(800)");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceDescription")
                        .HasColumnType("VARCHAR(800)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("CHAR(1)");

                    b.HasKey("Id");

                    b.ToTable("Request");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Demand = "trocar a tinta",
                            EquipmentId = 1,
                            PersonId = 1,
                            ServiceDescription = "tinta trocada - 2 pila",
                            Status = "O"
                        });
                });

            modelBuilder.Entity("ProjetoFinal_API.Models.Taxation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Percentage")
                        .HasColumnType("float");

                    b.Property<string>("TaxDescription")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("Taxation");
                });

            modelBuilder.Entity("CompanyPerson", b =>
                {
                    b.HasOne("ProjetoFinal_API.Models.Company", null)
                        .WithMany()
                        .HasForeignKey("CompaniesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinal_API.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoFinal_API.Models.Equipment", b =>
                {
                    b.HasOne("ProjetoFinal_API.Models.Request", null)
                        .WithMany("Equipments")
                        .HasForeignKey("RequestId");
                });

            modelBuilder.Entity("ProjetoFinal_API.Models.Person", b =>
                {
                    b.HasOne("ProjetoFinal_API.Models.Request", null)
                        .WithMany("People")
                        .HasForeignKey("RequestId");
                });

            modelBuilder.Entity("ProjetoFinal_API.Models.Request", b =>
                {
                    b.Navigation("Equipments");

                    b.Navigation("People");
                });
#pragma warning restore 612, 618
        }
    }
}
