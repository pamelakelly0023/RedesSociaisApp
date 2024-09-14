using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedesSociaisApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConfigurationDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfis_Contas_IdConta",
                table: "Perfis");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfis_Contas_IdConta",
                table: "Perfis",
                column: "IdConta",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfis_Contas_IdConta",
                table: "Perfis");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfis_Contas_IdConta",
                table: "Perfis",
                column: "IdConta",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
