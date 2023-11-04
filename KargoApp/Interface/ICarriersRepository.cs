using KargoApp.Models;

namespace KargoApp.Interface
{
    public interface ICarriersRepository
    {
        ICollection<Carriers> GetCarriers();
        bool CarrierExist(int carrierId);
        bool CreateCarrier(Carriers carrier);
        bool UpdateCarrier(Carriers carrier);
        bool DeleteCarrier(Carriers carrier);
        bool Save();
    }
}
