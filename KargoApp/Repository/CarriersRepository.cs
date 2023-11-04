using KargoApp.Data;
using KargoApp.Interface;
using KargoApp.Models;
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
            return _context.Carriers.OrderBy(p => p.CarrierId).ToList();
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

        public bool UpdateCarrier(Carriers carriers)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCarrier(Carriers carriers)
        {
            throw new NotImplementedException();
        }
    }
}
