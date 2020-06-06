﻿// <auto-generated />
using System;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Ebay
{
    [DbContext(typeof(EbayDatabaseFirstDbContext))]
    partial class EbayDatabaseFirstDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("some_id_of_user");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 6, 6, 17, 27, 22, 178, DateTimeKind.Local).AddTicks(4938));

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("some_id_of_user");

                    b.Property<DateTime>("UpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 6, 6, 17, 27, 22, 178, DateTimeKind.Local).AddTicks(4938));

                    b.Property<string>("ZipPostCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.ToTable("Address","common");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.Cart", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cart","sales");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.CartProduct", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CartId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartProduct","sales");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.ToTable("Customer","common");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.ToTable("Product","common");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.ProductShippingRate", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ShippingRateId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ShippingRateId");

                    b.HasIndex("ShippingRateId");

                    b.ToTable("ProductShippingRate","common");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.ShippingRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstDay")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(3,2)");

                    b.Property<int>("SecondDay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ShippingRate","common");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.Cart", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.Customer", null)
                        .WithMany("Carts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.CartProduct", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.Cart", null)
                        .WithMany("CartProducts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.Product", null)
                        .WithMany("CartProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.Customer", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.ProductShippingRate", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.Product", null)
                        .WithMany("ProductShippingRates")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.ShippingRate", null)
                        .WithMany("ProductShippingRates")
                        .HasForeignKey("ShippingRateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
