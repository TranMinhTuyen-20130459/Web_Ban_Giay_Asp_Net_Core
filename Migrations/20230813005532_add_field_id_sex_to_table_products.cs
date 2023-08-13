using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Ban_Giay_Asp_Net_Core.Migrations
{
    public partial class add_field_id_sex_to_table_products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "id_sex",
                table: "Products",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_sex",
                table: "Products");
        }
    }
}
