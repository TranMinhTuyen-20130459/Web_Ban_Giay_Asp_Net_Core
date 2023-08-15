using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Ban_Giay_Asp_Net_Core.Migrations
{
    public partial class update_table_order_details_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name_size",
                table: "Order_Details",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order_Details",
                keyColumn: "name_size",
                keyValue: null,
                column: "name_size",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "name_size",
                table: "Order_Details",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
