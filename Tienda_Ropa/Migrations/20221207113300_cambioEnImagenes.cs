using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaRopa.Migrations
{
    /// <inheritdoc />
    public partial class cambioEnImagenes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_TipoAplicacion_TipoAplicacio",
                table: "Producto");

            migrationBuilder.AlterColumn<int>(
                name: "TipoAplicacio",
                table: "Producto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ImagenUrl",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_TipoAplicacion_TipoAplicacio",
                table: "Producto",
                column: "TipoAplicacio",
                principalTable: "TipoAplicacion",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_TipoAplicacion_TipoAplicacio",
                table: "Producto");

            migrationBuilder.AlterColumn<int>(
                name: "TipoAplicacio",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagenUrl",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_TipoAplicacion_TipoAplicacio",
                table: "Producto",
                column: "TipoAplicacio",
                principalTable: "TipoAplicacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
