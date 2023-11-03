using KargoApp.Models;

namespace KargoApp.Interface
{
    public interface IOrderRepository
    {
        ICollection<Orders> GetOrders();
        Orders GetOrdersById(int orderId);
        Orders GetOrdersByDesi(int orderDesi);  
        Orders GetOrdersByOrderTime(DateTime orderTime);
        Orders GetOrdersByCarrierCost(decimal  orderCarrierCost);
        bool OrderExist(int orderId);
    }
}
