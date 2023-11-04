
using KargoApp.Models;

namespace KargoApp.Interface
{
    public interface IOrderRepository
    {
        ICollection<Orders> GetOrders();
        Orders GetOrdersById(int orderId);
        bool OrderExist(int orderId);
        bool CreateOrder(Orders order);
        bool UpdateOrder(Orders order);
        bool DeleteOrder(Orders order);
        bool Save();
        ICollection<Orders> GetOrdersWithCarriers();


    }
}
