using KargoApp.Data;
using KargoApp.Interface;
using KargoApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace KargoApp.Repository
{
    public class CarriersRepository : ICarriersRepository
    {
        private readonly DataContext _context;

        public CarriersRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Carriers> GetCarriers() 
        {
            var carriers = _context.Carriers.Include(p => p.CarrierConfigurations).ToList();
          
            return (ICollection<Carriers>)carriers;

        }
        public bool CreateCarrier(Carriers carrier)
        {
            _context.Add(carrier);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCarrier(Carriers carrier)
        {
            _context.Update(carrier);
            return Save();
        }

        public bool DeleteCarrier(Carriers carrier)
        {
            _context.Remove(carrier);
            return Save();
        }
        public bool CarrierExist(int carrierId)
        {
            return _context.Orders.Any(p => p.CarrierId == carrierId);
        }
        
    }
}
