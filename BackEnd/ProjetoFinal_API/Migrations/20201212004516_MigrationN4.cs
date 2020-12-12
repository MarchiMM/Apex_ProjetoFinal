using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal_API.Migrations
{
    public partial class MigrationN4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "Request",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "RequestTaxation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    TaxationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTaxation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestTaxation_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestTaxation_Taxation_TaxationId",
                        column: x => x.TaxationId,
                        principalTable: "Taxation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestTaxation_RequestId",
                table: "RequestTaxation",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestTaxation_TaxationId",
                table: "RequestTaxation",
                column: "TaxationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestTaxation");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Request");
        }
    }
}
