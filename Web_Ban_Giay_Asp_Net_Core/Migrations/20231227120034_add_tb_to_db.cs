using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Ban_Giay_Asp_Net_Core.Migrations
{
    public partial class add_tb_to_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_method_payment",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_status_payment",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Method_Payments",
                columns: table => new
                {
                    id_method_payment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_method = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Method_Payments", x => x.id_method_payment);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Status_Orders",
                columns: table => new
                {
                    id_status_order = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status_Orders", x => x.id_status_order);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Status_Payments",
                columns: table => new
                {
                    id_status_payment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status_Payments", x => x.id_status_payment);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_id_method_payment",
                table: "Orders",
                column: "id_method_payment");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_id_status_order",
                table: "Orders",
                column: "id_status_order");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_id_status_payment",
                table: "Orders",
                column: "id_status_payment");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Method_Payments_id_method_payment",
                table: "Orders",
                column: "id_method_payment",
                principalTable: "Method_Payments",
                principalColumn: "id_method_payment",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Status_Orders_id_status_order",
                table: "Orders",
                column: "id_status_order",
                principalTable: "Status_Orders",
                principalColumn: "id_status_order",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Status_Payments_id_status_payment",
                table: "Orders",
                column: "id_status_payment",
                principalTable: "Status_Payments",
                principalColumn: "id_status_payment",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Method_Payments_id_method_payment",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Status_Orders_id_status_order",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Status_Payments_id_status_payment",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Method_Payments");

            migrationBuilder.DropTable(
                name: "Status_Orders");

            migrationBuilder.DropTable(
                name: "Status_Payments");

            migrationBuilder.DropIndex(
                name: "IX_Orders_id_method_payment",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_id_status_order",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_id_status_payment",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "id_method_payment",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "id_status_payment",
                table: "Orders");
        }
    }
}
