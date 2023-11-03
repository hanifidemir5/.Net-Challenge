using KargoApp.Data;
using KargoApp.Interface;
using KargoApp.Models;

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
    }
}
