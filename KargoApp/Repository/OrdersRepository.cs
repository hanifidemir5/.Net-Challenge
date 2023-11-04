using KargoApp.Data;
using KargoApp.Interface;
using KargoApp.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.Orders.ToList();
        }
        public ICollection<Orders> GetOrdersWithCarriers()
        {
            return _context.Orders.Include(p => p.Carrier).ToList();
        }
        public Orders GetOrdersById(int orderId)
        {
            return _context.Orders.Where(p => p.OrderId == orderId).FirstOrDefault();
        }

        public bool OrderExist(int orderId)
        {
            return _context.Orders.Any(p => p.OrderId == orderId);
        }
        public Orders GetOrder(int orderId) 
        {
            return _context.Orders.Where(o => o.OrderId == orderId).FirstOrDefault();
        }
        public bool CreateOrder(Orders order)
        {
            _context.Add(order);
            return Save();
        }
        public bool UpdateOrder(Orders order)
        {
            _context.Update(order);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true:false;
        }

        public bool DeleteOrder(Orders order)
        {
            _context.Remove(order);
            return Save();
        }
    }
}
