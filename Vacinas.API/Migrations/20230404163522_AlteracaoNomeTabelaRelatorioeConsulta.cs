using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vacinas.API.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoNomeTabelaRelatorioeConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relatorio_Consulta_ConsultaId",
                table: "Relatorio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relatorio",
                table: "Relatorio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consulta",
                table: "Consulta");

            migrationBuilder.RenameTable(
                name: "Relatorio",
                newName: "tbl_relatorio");

            migrationBuilder.RenameTable(
                name: "Consulta",
                newName: "tbl_consulta");

            migrationBuilder.RenameIndex(
                name: "IX_Relatorio_ConsultaId",
                table: "tbl_relatorio",
                newName: "IX_tbl_relatorio_ConsultaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_relatorio",
                table: "tbl_relatorio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_consulta",
                table: "tbl_consulta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_relatorio_tbl_consulta_ConsultaId",
                table: "tbl_relatorio",
                column: "ConsultaId",
                principalTable: "tbl_consulta",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_relatorio_tbl_consulta_ConsultaId",
                table: "tbl_relatorio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_relatorio",
                table: "tbl_relatorio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_consulta",
                table: "tbl_consulta");

            migrationBuilder.RenameTable(
                name: "tbl_relatorio",
                newName: "Relatorio");

            migrationBuilder.RenameTable(
                name: "tbl_consulta",
                newName: "Consulta");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_relatorio_ConsultaId",
                table: "Relatorio",
                newName: "IX_Relatorio_ConsultaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relatorio",
                table: "Relatorio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consulta",
                table: "Consulta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Relatorio_Consulta_ConsultaId",
                table: "Relatorio",
                column: "ConsultaId",
                principalTable: "Consulta",
                principalColumn: "Id");
        }
    }
}
