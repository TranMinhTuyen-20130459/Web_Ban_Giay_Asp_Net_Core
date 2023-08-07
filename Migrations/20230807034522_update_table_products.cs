using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Ban_Giay_Asp_Net_Core.Migrations
{
    public partial class update_table_products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "listed_price",
                table: "Products",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "promotional_price",
                table: "Products",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "listed_price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "promotional_price",
                table: "Products");
        }
    }
}
