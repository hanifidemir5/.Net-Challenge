using KargoApp.Data;
using KargoApp.Interface;
using KargoApp.Models;

namespace KargoApp.Repository
{
    public class OrdersRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrdersRepository(DataContext context) 
        { 
           _context = context;
        }
        
        public ICollection<Orders> GetOrders()
        {
            return _context.Orders.OrderBy(p => p.OrderId).ToList();
        }
        public Orders GetOrdersById(int orderId)
        {
            return _context.Orders.Where(p => p.OrderId == orderId).FirstOrDefault();
        }

        public Orders GetOrdersByDesi(int orderDesi)
        {
            return _context.Orders.Where(p => p.OrderDesi == orderDesi).FirstOrDefault();
        }

        public Orders GetOrdersByOrderTime(DateTime orderTime)
        {
            return _context.Orders.Where(p => p.OrderTime == orderTime).FirstOrDefault();
        }

        public Orders GetOrdersByCarrierCost(decimal orderCarrierCost)
        {
            return _context.Orders.Where(p=> p.OrderCarrierCost == orderCarrierCost).FirstOrDefault();
        }

        public bool OrderExist(int orderId)
        {
            return _context.Orders.Any(p => p.OrderId == orderId);
        }

        
    }
}
