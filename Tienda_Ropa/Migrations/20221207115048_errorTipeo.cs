using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaRopa.Migrations
{
    /// <inheritdoc />
    public partial class errorTipeo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_TipoAplicacion_TipoAplicacio",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_TipoAplicacio",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "TipoAplicacio",
                table: "Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_TipoAplicacionId",
                table: "Producto",
                column: "TipoAplicacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_TipoAplicacion_TipoAplicacionId",
                table: "Producto",
                column: "TipoAplicacionId",
                principalTable: "TipoAplicacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_TipoAplicacion_TipoAplicacionId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_TipoAplicacionId",
                table: "Producto");

            migrationBuilder.AddColumn<int>(
                name: "TipoAplicacio",
                table: "Producto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_TipoAplicacio",
                table: "Producto",
                column: "TipoAplicacio");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_TipoAplicacion_TipoAplicacio",
                table: "Producto",
                column: "TipoAplicacio",
                principalTable: "TipoAplicacion",
                principalColumn: "Id");
        }
    }
}
