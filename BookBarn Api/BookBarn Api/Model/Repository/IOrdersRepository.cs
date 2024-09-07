using BookBarn_Api.Model.Entities;

namespace BookBarn_Api.Model.Repository
{
    public interface IOrdersRepository
    {
        Task AddOrder(Order order);
        Task<List<Order>> GetOrdersById(int orderId);

        Task<List<Order>> GetAdminOrders();

        Task<List<Order>> GetUserOrders(int userId);

        Task UpdateOrder(Order order,int orderId);

    }
}
