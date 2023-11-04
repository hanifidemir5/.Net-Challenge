using KargoApp.Data;
using KargoApp.Interface;
using KargoApp.Models;
using Microsoft.EntityFrameworkCore;

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
        public bool UpdateCarrierConfiguration(CarrierConfigurations carrierConfiguration)
        {
            var saved = _context.Update(carrierConfiguration);
            return Save();
        }

        public bool DeleteCarrierConfiguration(CarrierConfigurations carrierConfiguration)
        {
            _context.Remove(carrierConfiguration);
            return Save();
        }

        public bool CarrierConfigurationExist(int carrierConfigruationId)
        {
            return _context.CarrierConfigurations.Any(p => p.CarrierConfigurationId == carrierConfigruationId);
        }

        public ICollection<CarrierConfigurations> GetCarrierConfigurationsWithCarrier()
        {
            var x = _context.CarrierConfigurations.Include(p => p.Carrier).ToList();
            return x;
        }

    }
}
