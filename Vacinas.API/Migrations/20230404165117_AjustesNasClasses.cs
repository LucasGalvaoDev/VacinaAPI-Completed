using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vacinas.API.Migrations
{
    /// <inheritdoc />
    public partial class AjustesNasClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_relatorio_tbl_consulta_ConsultaId",
                table: "tbl_relatorio");

            migrationBuilder.DropIndex(
                name: "IX_tbl_relatorio_ConsultaId",
                table: "tbl_relatorio");

            migrationBuilder.DropColumn(
                name: "ConsultaId",
                table: "tbl_relatorio");

            migrationBuilder.DropColumn(
                name: "Solicitante",
                table: "tbl_relatorio");

            migrationBuilder.AddColumn<int>(
                name: "SolicitanteId",
                table: "tbl_relatorio",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SolicitanteId",
                table: "tbl_relatorio");

            migrationBuilder.AddColumn<int>(
                name: "ConsultaId",
                table: "tbl_relatorio",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Solicitante",
                table: "tbl_relatorio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_relatorio_ConsultaId",
                table: "tbl_relatorio",
                column: "ConsultaId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_relatorio_tbl_consulta_ConsultaId",
                table: "tbl_relatorio",
                column: "ConsultaId",
                principalTable: "tbl_consulta",
                principalColumn: "Id");
        }
    }
}
