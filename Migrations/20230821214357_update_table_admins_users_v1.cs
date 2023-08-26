using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Ban_Giay_Asp_Net_Core.Migrations
{
    public partial class update_table_admins_users_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Details_Admins_id_admin",
                table: "Role_Details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.AddColumn<long>(
                name: "id_user",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id_admin",
                table: "Role_Details",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<long>(
                name: "id_admin",
                table: "Admins",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id_user");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "id_admin");

            migrationBuilder.CreateIndex(
                name: "IX_Users_email",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_email",
                table: "Admins",
                column: "email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Details_Admins_id_admin",
                table: "Role_Details",
                column: "id_admin",
                principalTable: "Admins",
                principalColumn: "id_admin",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Details_Admins_id_admin",
                table: "Role_Details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_email",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_email",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "id_user",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "id_admin",
                table: "Admins");

            migrationBuilder.AlterColumn<string>(
                name: "id_admin",
                table: "Role_Details",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "email");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Details_Admins_id_admin",
                table: "Role_Details",
                column: "id_admin",
                principalTable: "Admins",
                principalColumn: "email",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
