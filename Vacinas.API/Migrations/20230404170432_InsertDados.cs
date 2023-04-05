using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vacinas.API.Migrations
{
    /// <inheritdoc />
    public partial class InsertDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "tbl_consulta",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "tbl_consulta",
                columns: new[] { "Id", "Cpf", "DataSolicitacao", "Nome" },
                values: new object[,]
                {
                    { 1, "13119056774", new DateTime(2023, 4, 4, 14, 4, 32, 200, DateTimeKind.Local).AddTicks(3921), "Lucas Galvão" },
                    { 2, "56898787874", new DateTime(2023, 4, 4, 14, 4, 32, 200, DateTimeKind.Local).AddTicks(3996), "Lucas Coutinho" }
                });

            migrationBuilder.InsertData(
                table: "tbl_relatorio",
                columns: new[] { "Id", "DataSolicitacao", "DescricaoRelatorio", "QuantidadeTotalVacinados", "SolicitanteId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 4, 14, 4, 32, 200, DateTimeKind.Local).AddTicks(3979), "Relatório Vacinas Pfizer aplicadas no RJ dia 03/03/2023", 71, 1 },
                    { 2, new DateTime(2023, 4, 4, 14, 4, 32, 200, DateTimeKind.Local).AddTicks(4010), "Relatório Vacinas Pfizer aplicadas no RJ dia 15/03/2023", 50, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_consulta",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_consulta",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_relatorio",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_relatorio",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Cpf",
                table: "tbl_consulta",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
