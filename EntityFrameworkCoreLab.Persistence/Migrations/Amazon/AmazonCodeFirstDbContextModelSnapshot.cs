﻿// <auto-generated />
using System;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Amazon
{
    [DbContext(typeof(AmazonCodeFirstDbContext))]
    partial class AmazonCodeFirstDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ZipPostCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.Cart", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.CartProduct", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CartId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartProduct");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.Customer", b =>
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

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.Product", b =>
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

                    b.ToTable("Product");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.ProductShippingRate", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ShippingRateId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ShippingRateId");

                    b.HasIndex("ShippingRateId");

                    b.ToTable("ProductShippingRate");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.ShippingRate", b =>
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

                    b.ToTable("ShippingRate");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.Cart", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.Customer", null)
                        .WithMany("Carts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.CartProduct", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.Cart", null)
                        .WithMany("CartProducts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.Product", null)
                        .WithMany("CartProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.Customer", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.ProductShippingRate", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.Product", null)
                        .WithMany("ProductShippingRates")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon.ShippingRate", null)
                        .WithMany("ProductShippingRates")
                        .HasForeignKey("ShippingRateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
