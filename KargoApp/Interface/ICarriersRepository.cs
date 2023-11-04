using KargoApp.Models;

namespace KargoApp.Interface
{
    public interface ICarriersRepository
    {
        ICollection<Carriers> GetCarriers();
        bool CreateCarrier(Carriers carriers);
        bool UpdateCarrier(Carriers carriers);
        bool DeleteCarrier(Carriers carriers);
        bool Save();
    }
}
