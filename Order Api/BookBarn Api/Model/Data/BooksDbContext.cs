using Microsoft.EntityFrameworkCore;
using BookBarn_Api.Model.Entities;

namespace BookBarn_Api.Model.Data
{
    public class BooksDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public BooksDbContext(DbContextOptions<BooksDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
            new Order
            {
                OrderId = 1,
                userId = 1,
                CartId = 1001,
                OrderStatus = "Processing",
                TotalAmount = 1500,
                ShippingAddress = "123 Maple Street, Springfield, IL",
                PaymentMethod = "Credit Card",
                OrderDate = new DateTime(2024, 9, 6),     
            },
            new Order
            {
                OrderId = 2,
                userId = 2,
                CartId = 1002,
                OrderStatus = "Shipped",
                TotalAmount = 2500,
                ShippingAddress = "456 Oak Avenue, Seattle, WA",
                PaymentMethod = "PayPal",
                OrderDate = new DateTime(2024, 9, 7),
            },
            new Order
            {
                OrderId = 3,
                userId = 3,
                CartId = 1003,
                OrderStatus = "Delivered",
                TotalAmount = 1800,
                ShippingAddress = "789 Pine Road, Miami, FL",
                PaymentMethod = "Debit Card",
                OrderDate = new DateTime(2024, 9, 8),
            }
        );
        }   
    }
}
