using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookBarn_Api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CartId", "OrderDate", "OrderStatus", "PaymentMethod", "ShippingAddress", "TotalAmount", "userId" },
                values: new object[,]
                {
                    { 1, 1001, new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "Credit Card", "123 Maple Street, Springfield, IL", 1500.0, 0 },
                    { 2, 1002, new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipped", "PayPal", "456 Oak Avenue, Seattle, WA", 2500.0, 0 },
                    { 3, 1003, new DateTime(2024, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", "Debit Card", "789 Pine Road, Miami, FL", 1800.0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
