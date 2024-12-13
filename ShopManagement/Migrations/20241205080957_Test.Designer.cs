﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopManagement.Models;

#nullable disable

namespace ShopManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241205080957_Test")]
    partial class Test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopManagement.Models.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Bill_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillId"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("Customer_Id");

                    b.Property<decimal?>("SalesPercent")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<int>("StaffId")
                        .HasColumnType("int")
                        .HasColumnName("Staff_Id");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("BillId")
                        .HasName("PK__Bill__CF6E7DA36D882E99");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StaffId");

                    b.ToTable("Bill", (string)null);
                });

            modelBuilder.Entity("ShopManagement.Models.BillDetail", b =>
                {
                    b.Property<int>("BillDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BillDetail_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillDetailId"));

                    b.Property<int>("BillId")
                        .HasColumnType("int")
                        .HasColumnName("Bill_Id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("WarehouseProductId")
                        .HasColumnType("int")
                        .HasColumnName("WarehouseProduct_Id");

                    b.HasKey("BillDetailId")
                        .HasName("PK__BillDeta__5F6D0CC6E6C94CAF");

                    b.HasIndex("BillId");

                    b.HasIndex("ProductId");

                    b.ToTable("BillDetail", (string)null);
                });

            modelBuilder.Entity("ShopManagement.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Brand_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("BrandId")
                        .HasName("PK__Brand__AAB3214F95C9433D");

                    b.ToTable("Brand", (string)null);
                });

            modelBuilder.Entity("ShopManagement.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__A4AE64D8F4F24C90");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("ShopManagement.Models.ImportBill", b =>
                {
                    b.Property<int>("ImportBillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ImportBill_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImportBillId"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("Brand_Id");

                    b.Property<DateTime>("ImportDate")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("TotalPayment")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("Total_Payment");

                    b.HasKey("ImportBillId")
                        .HasName("PK__ImportBi__5145A970B76B46B1");

                    b.HasIndex("BrandId");

                    b.ToTable("ImportBill", (string)null);
                });

            modelBuilder.Entity("ShopManagement.Models.ImportBillDetail", b =>
                {
                    b.Property<int>("ImportBillDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ImportBillDetail_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImportBillDetailId"));

                    b.Property<int>("ImportBillId")
                        .HasColumnType("int")
                        .HasColumnName("ImportBill_Id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ImportBillDetailId")
                        .HasName("PK__ImportBi__FC316DB6B2C6474D");

                    b.HasIndex("ImportBillId");

                    b.HasIndex("ProductId");

                    b.ToTable("ImportBillDetail", (string)null);
                });

            modelBuilder.Entity("ShopManagement.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("Brand_Id");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ProductId")
                        .HasName("PK__Product__B40CC6CD55271300");

                    b.HasIndex("BrandId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("ShopManagement.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RoleId")
                        .HasName("PK__Role__8AFACE1A4055180A");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("ShopManagement.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StaffId")
                        .HasName("PK__Staff__96D4AB1727663F0C");

                    b.HasIndex("RoleId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("ShopManagement.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Warehouse_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarehouseId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("Stock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("WarehouseId")
                        .HasName("PK__Warehous__3D90D0544AD98879");

                    b.ToTable("Warehouse", (string)null);
                });

            modelBuilder.Entity("ShopManagement.Models.WarehouseProduct", b =>
                {
                    b.Property<int>("WarehouseProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("WarehouseProduct_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarehouseProductId"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("WarehouseId")
                        .HasColumnType("int")
                        .HasColumnName("Warehouse_Id");

                    b.HasKey("WarehouseProductId")
                        .HasName("PK__Warehous__AA37012BCC300822");

                    b.HasIndex("ProductId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("WarehouseProduct", (string)null);
                });

            modelBuilder.Entity("ShopManagement.Models.Bill", b =>
                {
                    b.HasOne("ShopManagement.Models.Customer", "Customer")
                        .WithMany("Bills")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK__Bill__Customer_I__534D60F1");

                    b.HasOne("ShopManagement.Models.Staff", "Staff")
                        .WithMany("Bills")
                        .HasForeignKey("StaffId")
                        .IsRequired()
                        .HasConstraintName("FK__Bill__Staff_Id__52593CB8");

                    b.Navigation("Customer");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("ShopManagement.Models.BillDetail", b =>
                {
                    b.HasOne("ShopManagement.Models.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("BillId")
                        .IsRequired()
                        .HasConstraintName("FK__BillDetai__Bill___5629CD9C");

                    b.HasOne("ShopManagement.Models.Product", "Product")
                        .WithMany("BillDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__BillDetai__Produ__571DF1D5");

                    b.Navigation("Bill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopManagement.Models.ImportBill", b =>
                {
                    b.HasOne("ShopManagement.Models.Brand", "Brand")
                        .WithMany("ImportBills")
                        .HasForeignKey("BrandId")
                        .IsRequired()
                        .HasConstraintName("FK__ImportBil__Brand__4316F928");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("ShopManagement.Models.ImportBillDetail", b =>
                {
                    b.HasOne("ShopManagement.Models.ImportBill", "ImportBill")
                        .WithMany("ImportBillDetails")
                        .HasForeignKey("ImportBillId")
                        .IsRequired()
                        .HasConstraintName("FK__ImportBil__Impor__45F365D3");

                    b.HasOne("ShopManagement.Models.Product", "Product")
                        .WithMany("ImportBillDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__ImportBil__Produ__46E78A0C");

                    b.Navigation("ImportBill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopManagement.Models.Product", b =>
                {
                    b.HasOne("ShopManagement.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .IsRequired()
                        .HasConstraintName("FK__Product__Brand_I__3D5E1FD2");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("ShopManagement.Models.Staff", b =>
                {
                    b.HasOne("ShopManagement.Models.Role", "Role")
                        .WithMany("Staff")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_Staff_Role");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ShopManagement.Models.WarehouseProduct", b =>
                {
                    b.HasOne("ShopManagement.Models.Product", "Product")
                        .WithMany("WarehouseProducts")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_Product");

                    b.HasOne("ShopManagement.Models.Warehouse", "Warehouse")
                        .WithMany("WarehouseProducts")
                        .HasForeignKey("WarehouseId")
                        .HasConstraintName("FK_Warehouse");

                    b.Navigation("Product");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("ShopManagement.Models.Bill", b =>
                {
                    b.Navigation("BillDetails");
                });

            modelBuilder.Entity("ShopManagement.Models.Brand", b =>
                {
                    b.Navigation("ImportBills");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopManagement.Models.Customer", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("ShopManagement.Models.ImportBill", b =>
                {
                    b.Navigation("ImportBillDetails");
                });

            modelBuilder.Entity("ShopManagement.Models.Product", b =>
                {
                    b.Navigation("BillDetails");

                    b.Navigation("ImportBillDetails");

                    b.Navigation("WarehouseProducts");
                });

            modelBuilder.Entity("ShopManagement.Models.Role", b =>
                {
                    b.Navigation("Staff");
                });

            modelBuilder.Entity("ShopManagement.Models.Staff", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("ShopManagement.Models.Warehouse", b =>
                {
                    b.Navigation("WarehouseProducts");
                });
#pragma warning restore 612, 618
        }
    }
}