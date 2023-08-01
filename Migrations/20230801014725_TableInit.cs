using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Ban_Giay_Asp_Net_Core.Migrations
{
    public partial class TableInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    username = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fullname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    path_img_avatar = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.username);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    id_brand = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_brand = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.id_brand);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    id_log = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    src = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    web_browser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_level_log = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.id_log);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id_order = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    from_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    from_phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    from_address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    from_ward_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    from_district_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    from_province_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    from_ward_id = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    from_district_id = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    from_province_id = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    return_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    return_phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    return_address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    return_ward_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    return_district_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    return_province_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    return_ward_id = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    return_district_id = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    return_province_id = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email_customer = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    to_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    to_phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    to_address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    to_ward_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    to_district_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    to_province_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    to_ward_id = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    to_district_id = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    to_province_id = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    note = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ship_price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    order_value = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    time_order = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    time_updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    id_status_order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id_order);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Price_Ranges",
                columns: table => new
                {
                    name_price_range = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price_start = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    price_end = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price_Ranges", x => x.name_price_range);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id_role = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id_role);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    name_size = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.name_size);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Type_Products",
                columns: table => new
                {
                    id_type = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Products", x => x.id_type);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Role_Details",
                columns: table => new
                {
                    id_admin = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Details", x => new { x.id_admin, x.id_role });
                    table.ForeignKey(
                        name: "FK_Role_Details_Admins_id_admin",
                        column: x => x.id_admin,
                        principalTable: "Admins",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_Details_Roles_id_role",
                        column: x => x.id_role,
                        principalTable: "Roles",
                        principalColumn: "id_role",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id_product = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_product = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    star_review = table.Column<int>(type: "int", nullable: false),
                    id_status_product = table.Column<int>(type: "int", nullable: false),
                    id_brand = table.Column<int>(type: "int", nullable: false),
                    id_type_product = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id_product);
                    table.ForeignKey(
                        name: "FK_Products_Brands_id_brand",
                        column: x => x.id_brand,
                        principalTable: "Brands",
                        principalColumn: "id_brand",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Type_Products_id_type_product",
                        column: x => x.id_type_product,
                        principalTable: "Type_Products",
                        principalColumn: "id_type",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "History_Price_Products",
                columns: table => new
                {
                    id_price_product = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_product = table.Column<long>(type: "bigint", nullable: false),
                    listed_price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    promotional_price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    time_start = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    time_end = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History_Price_Products", x => x.id_price_product);
                    table.ForeignKey(
                        name: "FK_History_Price_Products_Products_id_product",
                        column: x => x.id_product,
                        principalTable: "Products",
                        principalColumn: "id_product",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Image_Products",
                columns: table => new
                {
                    id_image = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    path = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_product = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image_Products", x => x.id_image);
                    table.ForeignKey(
                        name: "FK_Image_Products_Products_id_product",
                        column: x => x.id_product,
                        principalTable: "Products",
                        principalColumn: "id_product",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Order_Details",
                columns: table => new
                {
                    id_order = table.Column<long>(type: "bigint", nullable: false),
                    id_product = table.Column<long>(type: "bigint", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Details", x => new { x.id_order, x.id_product });
                    table.ForeignKey(
                        name: "FK_Order_Details_Orders_id_order",
                        column: x => x.id_order,
                        principalTable: "Orders",
                        principalColumn: "id_order",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Details_Products_id_product",
                        column: x => x.id_product,
                        principalTable: "Products",
                        principalColumn: "id_product",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Size_Products",
                columns: table => new
                {
                    id_product = table.Column<long>(type: "bigint", nullable: false),
                    name_size = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantity_available = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size_Products", x => new { x.id_product, x.name_size });
                    table.ForeignKey(
                        name: "FK_Size_Products_Products_id_product",
                        column: x => x.id_product,
                        principalTable: "Products",
                        principalColumn: "id_product",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Size_Products_Sizes_name_size",
                        column: x => x.name_size,
                        principalTable: "Sizes",
                        principalColumn: "name_size",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_History_Price_Products_id_product",
                table: "History_Price_Products",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_Image_Products_id_product",
                table: "Image_Products",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_id_product",
                table: "Order_Details",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_Products_id_brand",
                table: "Products",
                column: "id_brand");

            migrationBuilder.CreateIndex(
                name: "IX_Products_id_type_product",
                table: "Products",
                column: "id_type_product");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Details_id_role",
                table: "Role_Details",
                column: "id_role");

            migrationBuilder.CreateIndex(
                name: "IX_Size_Products_name_size",
                table: "Size_Products",
                column: "name_size");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History_Price_Products");

            migrationBuilder.DropTable(
                name: "Image_Products");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Order_Details");

            migrationBuilder.DropTable(
                name: "Price_Ranges");

            migrationBuilder.DropTable(
                name: "Role_Details");

            migrationBuilder.DropTable(
                name: "Size_Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Type_Products");
        }
    }
}
