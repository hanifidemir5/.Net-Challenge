using KargoApp.Data;
using KargoApp.Interface;
using KargoApp.Models;

namespace KargoApp.Repository
{
    public class CarrierConfigurationsRepository : ICarrierConfigurationsRepository
    {
        private DataContext _context;
        public CarrierConfigurationsRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<CarrierConfigurations> GetCarrierConfigurations() 
        {
            return _context.CarrierConfigurations.OrderBy(p=>p.CarrierConfigurationId).ToList();
        }
    }
}
