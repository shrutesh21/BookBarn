using BookBarn_Api.Model.Entities;
using BookBarn_Api.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookBarn_Api.Model.Data
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly BooksDbContext db;
        public OrdersRepository(BooksDbContext db)
        {
            this.db = db;
        }
        public async Task AddOrder(Order order)
        {
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
        }

        public async Task<List<Order>> GetOrdersById(int orderId)
        {
            return await db.Orders.Where(o => o.OrderId == orderId).ToListAsync();
        }

        public async Task<List<Order>> GetAdminOrders()
        {
            return await db.Orders.ToListAsync();
        }

        public async Task<List<Order>> GetUserOrders(int userId)
        {
            // Return all orders that have the specified CartId
            return await db.Orders.Where(o => o.userId == userId).ToListAsync();
        }


        public async Task UpdateOrder(Order order, int orderId)
        {
            // Find the existing order by OrderId
            var existingOrder = await db.Orders.FindAsync(orderId);

            if (existingOrder != null)
            {
                // Update properties of the existing order with new values
                existingOrder.OrderStatus = order.OrderStatus;
                existingOrder.ShippingAddress = order.ShippingAddress;

                // Save the changes to the database
                await db.SaveChangesAsync();
            }
        }

      
    }
}
