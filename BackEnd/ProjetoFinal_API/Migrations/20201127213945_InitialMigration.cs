﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal_API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Brand = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    Model = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    SerialNumber = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxDescription = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "CHAR(1)", nullable: false),
                    PersonType = table.Column<string>(type: "CHAR(1)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(11)", nullable: true),
                    Cnpj = table.Column<string>(type: "VARCHAR(12)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(16)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "CHAR(1)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    EquipamentId = table.Column<int>(type: "int", nullable: false),
                    Demand = table.Column<string>(type: "VARCHAR(800)", nullable: false),
                    ServiceDescription = table.Column<string>(type: "VARCHAR(800)", nullable: true),
                    TaxationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Request_Equipament_EquipamentId",
                        column: x => x.EquipamentId,
                        principalTable: "Equipament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_Taxation_TaxationId",
                        column: x => x.TaxationId,
                        principalTable: "Taxation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_CompanyId",
                table: "Person",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_EquipamentId",
                table: "Request",
                column: "EquipamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_PersonId",
                table: "Request",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_TaxationId",
                table: "Request",
                column: "TaxationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Equipament");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Taxation");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}