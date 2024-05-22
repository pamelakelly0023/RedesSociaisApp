using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedesSociaisApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class criarColunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_IdPerfil",
                table: "Publicacoes",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_Perfis_IdConta",
                table: "Perfis",
                column: "IdConta",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Perfis_Contas_IdConta",
                table: "Perfis",
                column: "IdConta",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacoes_Perfis_IdPerfil",
                table: "Publicacoes",
                column: "IdPerfil",
                principalTable: "Perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfis_Contas_IdConta",
                table: "Perfis");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_Perfis_IdPerfil",
                table: "Publicacoes");

            migrationBuilder.DropIndex(
                name: "IX_Publicacoes_IdPerfil",
                table: "Publicacoes");

            migrationBuilder.DropIndex(
                name: "IX_Perfis_IdConta",
                table: "Perfis");

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
    }
}
