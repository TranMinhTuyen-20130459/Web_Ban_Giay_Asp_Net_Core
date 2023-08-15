﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_Ban_Giay_Asp_Net_Core.Entities.Config;

#nullable disable

namespace Web_Ban_Giay_Asp_Net_Core.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230815091657_update_table_orders_v1")]
    partial class update_table_orders_v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.Admin", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("fullname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("path_img_avatar")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("username");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.Brand", b =>
                {
                    b.Property<int>("id_brand")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name_brand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id_brand");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.HistoryPriceProduct", b =>
                {
                    b.Property<long>("id_price_product")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("create_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<long>("id_product")
                        .HasColumnType("bigint");

                    b.Property<decimal>("listed_price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("promotional_price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime?>("time_end")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("time_start")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id_price_product");

                    b.HasIndex("id_product");

                    b.ToTable("History_Price_Products");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.ImageProduct", b =>
                {
                    b.Property<long>("id_image")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("id_product")
                        .HasColumnType("bigint");

                    b.Property<string>("path")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id_image");

                    b.HasIndex("id_product");

                    b.ToTable("Image_Products");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.Log", b =>
                {
                    b.Property<int>("id_log")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("create_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("id_address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("id_level_log")
                        .HasColumnType("int");

                    b.Property<int>("id_user")
                        .HasColumnType("int");

                    b.Property<string>("src")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("status")
                        .HasColumnType("longtext");

                    b.Property<string>("web_browser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id_log");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.Order", b =>
                {
                    b.Property<long>("id_order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("email_customer")
                        .HasColumnType("longtext");

                    b.Property<string>("from_address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("from_district_id")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("from_district_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("from_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("from_phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("from_province_id")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("from_province_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("from_ward_id")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("from_ward_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("id_status_order")
                        .HasColumnType("int");

                    b.Property<string>("note")
                        .HasColumnType("longtext");

                    b.Property<decimal>("order_value")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("return_address")
                        .HasColumnType("longtext");

                    b.Property<string>("return_district_id")
                        .HasColumnType("longtext");

                    b.Property<string>("return_district_name")
                        .HasColumnType("longtext");

                    b.Property<string>("return_name")
                        .HasColumnType("longtext");

                    b.Property<string>("return_phone")
                        .HasColumnType("longtext");

                    b.Property<string>("return_province_id")
                        .HasColumnType("longtext");

                    b.Property<string>("return_province_name")
                        .HasColumnType("longtext");

                    b.Property<string>("return_ward_id")
                        .HasColumnType("longtext");

                    b.Property<string>("return_ward_name")
                        .HasColumnType("longtext");

                    b.Property<decimal>("ship_price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("time_order")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("time_updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("to_address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("to_district_id")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("to_district_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("to_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("to_phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("to_province_id")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("to_province_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("to_ward_id")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("to_ward_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("total_price")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("id_order");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.OrderDetail", b =>
                {
                    b.Property<long>("id_order_detail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("id_order")
                        .HasColumnType("bigint");

                    b.Property<long>("id_product")
                        .HasColumnType("bigint");

                    b.Property<string>("name_size")
                        .HasColumnType("longtext");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("id_order_detail");

                    b.HasIndex("id_order");

                    b.HasIndex("id_product");

                    b.ToTable("Order_Details");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.PriceRange", b =>
                {
                    b.Property<string>("name_price_range")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("price_end")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("price_start")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("name_price_range");

                    b.ToTable("Price_Ranges");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.Product", b =>
                {
                    b.Property<long>("id_product")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("id_brand")
                        .HasColumnType("int");

                    b.Property<byte>("id_sex")
                        .HasColumnType("tinyint unsigned");

                    b.Property<int>("id_status_product")
                        .HasColumnType("int");

                    b.Property<int>("id_type_product")
                        .HasColumnType("int");

                    b.Property<decimal>("listed_price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("name_product")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("promotional_price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("star_review")
                        .HasColumnType("int");

                    b.HasKey("id_product");

                    b.HasIndex("id_brand");

                    b.HasIndex("id_type_product");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.Role", b =>
                {
                    b.Property<int>("id_role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name_role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id_role");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.RoleDetail", b =>
                {
                    b.Property<string>("id_admin")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("id_role")
                        .HasColumnType("int");

                    b.HasKey("id_admin", "id_role");

                    b.HasIndex("id_role");

                    b.ToTable("Role_Details");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.Size", b =>
                {
                    b.Property<string>("name_size")
                        .HasColumnType("varchar(255)");

                    b.HasKey("name_size");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.SizeProduct", b =>
                {
                    b.Property<long>("id_product")
                        .HasColumnType("bigint");

                    b.Property<string>("name_size")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("quantity_available")
                        .HasColumnType("int");

                    b.HasKey("id_product", "name_size");

                    b.HasIndex("name_size");

                    b.ToTable("Size_Products");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.TypeProduct", b =>
                {
                    b.Property<int>("id_type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name_type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id_type");

                    b.ToTable("Type_Products");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.HistoryPriceProduct", b =>
                {
                    b.HasOne("Web_Ban_Giay_Asp_Net_Core.Entities.Product", "product")
                        .WithMany("list_history_price")
                        .HasForeignKey("id_product")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.ImageProduct", b =>
                {
                    b.HasOne("Web_Ban_Giay_Asp_Net_Core.Entities.Product", "product")
                        .WithMany("list_image")
                        .HasForeignKey("id_product")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.OrderDetail", b =>
                {
                    b.HasOne("Web_Ban_Giay_Asp_Net_Core.Entities.Order", "order")
                        .WithMany("list_order_details")
                        .HasForeignKey("id_order")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_Ban_Giay_Asp_Net_Core.Entities.Product", "product")
                        .WithMany("list_order_detail")
                        .HasForeignKey("id_product")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.Product", b =>
                {
                    b.HasOne("Web_Ban_Giay_Asp_Net_Core.Entities.Brand", "brand")
                        .WithMany("products")
                        .HasForeignKey("id_brand")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_Ban_Giay_Asp_Net_Core.Entities.TypeProduct", "type_product")
                        .WithMany("products")
                        .HasForeignKey("id_type_product")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("brand");

                    b.Navigation("type_product");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.RoleDetail", b =>
                {
                    b.HasOne("Web_Ban_Giay_Asp_Net_Core.Entities.Admin", "admin")
                        .WithMany("role_details")
                        .HasForeignKey("id_admin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_Ban_Giay_Asp_Net_Core.Entities.Role", "role")
                        .WithMany("role_details")
                        .HasForeignKey("id_role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("admin");

                    b.Navigation("role");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.SizeProduct", b =>
                {
                    b.HasOne("Web_Ban_Giay_Asp_Net_Core.Entities.Product", "product")
                        .WithMany("list_size")
                        .HasForeignKey("id_product")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_Ban_Giay_Asp_Net_Core.Entities.Size", "size")
                        .WithMany("size_products")
                        .HasForeignKey("name_size")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("size");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.Admin", b =>
                {
                    b.Navigation("role_details");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.Brand", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.Order", b =>
                {
                    b.Navigation("list_order_details");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.Product", b =>
                {
                    b.Navigation("list_history_price");

                    b.Navigation("list_image");

                    b.Navigation("list_order_detail");

                    b.Navigation("list_size");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.Role", b =>
                {
                    b.Navigation("role_details");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.Size", b =>
                {
                    b.Navigation("size_products");
                });

            modelBuilder.Entity("Web_Ban_Giay_Asp_Net_Core.Entities.TypeProduct", b =>
                {
                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}
