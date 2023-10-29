using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Ban_Giay_Asp_Net_Core.Migrations
{
    public partial class Init_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_id_brand",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Type_Products_id_type_product",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "id_type_product",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_brand",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_id_brand",
                table: "Products",
                column: "id_brand",
                principalTable: "Brands",
                principalColumn: "id_brand",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Type_Products_id_type_product",
                table: "Products",
                column: "id_type_product",
                principalTable: "Type_Products",
                principalColumn: "id_type",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_id_brand",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Type_Products_id_type_product",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "id_type_product",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "id_brand",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_id_brand",
                table: "Products",
                column: "id_brand",
                principalTable: "Brands",
                principalColumn: "id_brand");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Type_Products_id_type_product",
                table: "Products",
                column: "id_type_product",
                principalTable: "Type_Products",
                principalColumn: "id_type");
        }
    }
}
