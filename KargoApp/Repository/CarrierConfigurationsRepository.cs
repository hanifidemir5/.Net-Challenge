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
        public bool CreateCarrierConfiguration(CarrierConfigurations carrierConfiguration)
        {
            var saved = _context.Add(carrierConfiguration);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
