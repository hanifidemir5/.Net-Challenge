using KargoApp.Models;

namespace KargoApp.Interface
{
    public interface ICarrierConfigurationsRepository
    {
        ICollection<CarrierConfigurations> GetCarrierConfigurations();
    }
}
