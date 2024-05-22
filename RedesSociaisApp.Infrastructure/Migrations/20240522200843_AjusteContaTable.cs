using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedesSociaisApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjusteContaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_PerfilId",
                table: "Contas",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Perfis_PerfilId",
                table: "Contas",
                column: "PerfilId",
                principalTable: "Perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Perfis_PerfilId",
                table: "Contas");

            migrationBuilder.DropIndex(
                name: "IX_Contas_PerfilId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Contas");
        }
    }
}
