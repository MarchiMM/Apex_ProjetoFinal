using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal_API.Migrations
{
    public partial class MigrationN3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Request_RequestId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Request_RequestId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "CompanyPerson");

            migrationBuilder.DropIndex(
                name: "IX_Person_RequestId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_RequestId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Equipment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Taxation",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EffectiveDate",
                table: "Taxation",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Request_EquipmentId",
                table: "Request",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_PersonId",
                table: "Request",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CompanyId",
                table: "Person",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Company_CompanyId",
                table: "Person",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Equipment_EquipmentId",
                table: "Request",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Person_PersonId",
                table: "Request",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Company_CompanyId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Equipment_EquipmentId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Person_PersonId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_EquipmentId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_PersonId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Person_CompanyId",
                table: "Person");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Taxation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EffectiveDate",
                table: "Taxation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Equipment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompanyPerson",
                columns: table => new
                {
                    CompaniesId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPerson", x => new { x.CompaniesId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_CompanyPerson_Company_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyPerson_Person_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_RequestId",
                table: "Person",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_RequestId",
                table: "Equipment",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPerson_PeopleId",
                table: "CompanyPerson",
                column: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Request_RequestId",
                table: "Equipment",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Request_RequestId",
                table: "Person",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
