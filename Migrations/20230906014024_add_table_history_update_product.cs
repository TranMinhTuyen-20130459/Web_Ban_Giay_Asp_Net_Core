using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Ban_Giay_Asp_Net_Core.Migrations
{
    public partial class add_table_history_update_product : Migration
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

            migrationBuilder.CreateTable(
                name: "History_Update_Products",
                columns: table => new
                {
                    id_update_product = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_product = table.Column<long>(type: "bigint", nullable: false),
                    time_updated = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History_Update_Products", x => x.id_update_product);
                    table.ForeignKey(
                        name: "FK_History_Update_Products_Products_id_product",
                        column: x => x.id_product,
                        principalTable: "Products",
                        principalColumn: "id_product",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_History_Update_Products_id_product",
                table: "History_Update_Products",
                column: "id_product");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_id_brand",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Type_Products_id_type_product",
                table: "Products");

            migrationBuilder.DropTable(
                name: "History_Update_Products");

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
    }
}
