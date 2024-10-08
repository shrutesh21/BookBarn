﻿// <auto-generated />
using System;
using BookBarn_Api.Model.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookBarn_Api.Migrations
{
    [DbContext(typeof(BooksDbContext))]
    partial class BooksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookBarn_Api.Model.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            CartId = 1001,
                            OrderDate = new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = "Processing",
                            PaymentMethod = "Credit Card",
                            ShippingAddress = "123 Maple Street, Springfield, IL",
                            TotalAmount = 1500.0,
                            userId = 0
                        },
                        new
                        {
                            OrderId = 2,
                            CartId = 1002,
                            OrderDate = new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = "Shipped",
                            PaymentMethod = "PayPal",
                            ShippingAddress = "456 Oak Avenue, Seattle, WA",
                            TotalAmount = 2500.0,
                            userId = 0
                        },
                        new
                        {
                            OrderId = 3,
                            CartId = 1003,
                            OrderDate = new DateTime(2024, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = "Delivered",
                            PaymentMethod = "Debit Card",
                            ShippingAddress = "789 Pine Road, Miami, FL",
                            TotalAmount = 1800.0,
                            userId = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
