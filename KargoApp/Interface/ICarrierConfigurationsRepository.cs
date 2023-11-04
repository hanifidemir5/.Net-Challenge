using KargoApp.Models;

namespace KargoApp.Interface
{
    public interface ICarrierConfigurationsRepository
    {
        ICollection<CarrierConfigurations> GetCarrierConfigurations();
        bool CreateCarrierConfiguration(CarrierConfigurations carrierConfiguration);
        bool Save();

    }
}
