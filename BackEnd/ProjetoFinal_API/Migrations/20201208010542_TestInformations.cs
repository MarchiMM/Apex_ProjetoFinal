using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal_API.Migrations
{
    public partial class TestInformations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Test" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Brand", "Model", "RequestId", "SerialNumber", "Type" },
                values: new object[] { 1, "HP", "Ink Sak", null, "BIASYRTCBO2U3809R2U38R", "Impressora" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Address", "Cnpj", "CompanyId", "Cpf", "Email", "Name", "PersonType", "PhoneNumber", "RequestId", "Type" },
                values: new object[] { 1, "casa do caraio", "", 1, "12345678901", "email@gmail.com", "Thomas", "P", "1242535", null, "E" });

            migrationBuilder.InsertData(
                table: "Request",
                columns: new[] { "Id", "Demand", "EquipmentId", "PersonId", "ServiceDescription", "Status" },
                values: new object[] { 1, "trocar a tinta", 1, 1, "tinta trocada - 2 pila", "O" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Request",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
