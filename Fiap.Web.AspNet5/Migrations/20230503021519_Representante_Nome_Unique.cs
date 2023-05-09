using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.AspNet5.Migrations
{
    /// <inheritdoc />
    public partial class Representante_Nome_Unique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "REPRESENTANTE",
                newName: "NomeRepresentante");

            migrationBuilder.CreateIndex(
                name: "IX_REPRESENTANTE_NomeRepresentante",
                table: "REPRESENTANTE",
                column: "NomeRepresentante",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_REPRESENTANTE_NomeRepresentante",
                table: "REPRESENTANTE");

            migrationBuilder.RenameColumn(
                name: "NomeRepresentante",
                table: "REPRESENTANTE",
                newName: "Nome");
        }
    }
}
