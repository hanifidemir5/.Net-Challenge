using KargoApp.Models;

namespace KargoApp.Interface
{
    public interface ICarrierConfigurationsRepository
    {
        ICollection<CarrierConfigurations> GetCarrierConfigurations();
        bool CarrierConfigurationExist(int carrierConfigruationId);
        bool CreateCarrierConfiguration(CarrierConfigurations carrierConfiguration);
        bool UpdateCarrierConfiguration(CarrierConfigurations carrierConfiguration);
        bool DeleteCarrierConfiguration(CarrierConfigurations carrierConfiguration);
        public ICollection<CarrierConfigurations> GetCarrierConfigurationsWithCarrier();
        bool Save();


    }
}
